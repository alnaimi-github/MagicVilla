using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MagicVilla_Utility.StaticDetails;
using MagicVilla_Web.Dto.LoginDto;
using MagicVilla_Web.Dto.RegisterDto;
using MagicVilla_Web.Dto.ResponseDto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var loginResponse = await _authService.LoginAsync<ApiResponse>(model);
            if (loginResponse != null && loginResponse.IsSuccess)
            {
                var tokenDto = JsonConvert.DeserializeObject<TokenDto>
                    (Convert.ToString(loginResponse.Result)!)!;

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(tokenDto.AccessToken);

                var claims = jwt.Claims.Select(c => new Claim(c.Type, c.Value)).ToList();
                claims.Add(new Claim(
                    ClaimTypes.Role,
                    jwt.Claims.FirstOrDefault(x => x.Type == "role")?.Value!)); // Add 'role' claim
                claims.Add(new Claim(
                    ClaimTypes.Name,
                    jwt.Claims.FirstOrDefault(x => x.Type == "name")?.Value!)); // Add 'role' name
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                _tokenProvider.SetToken(tokenDto);
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                ModelState.AddModelError("ErrorMessages",
                    loginResponse.ErrorMessages.FirstOrDefault()!);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
          var roles = Enum.GetValues(typeof(Sd.Roles))
              .Cast<Sd.Roles>()
              .Select(role => new SelectListItem
              {
                  Text = role.ToString(),
                  Value = role.ToString()
              })
              .ToList();
          ViewBag.RoleList = roles;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDto model)
        {
                var registerResponse = await _authService.RegisterAsync<ApiResponse>(model);
                if (registerResponse!=null&&registerResponse.IsSuccess)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                        ModelState.AddModelError("ErrorMessages",
                            registerResponse.ErrorMessages.FirstOrDefault()!);
                    return View(model);
                }
            
           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            var token = _tokenProvider.GetToken();
            await _authService.LogoutAsync<ApiResponse>(token!);
            _tokenProvider.ClearToken();
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
