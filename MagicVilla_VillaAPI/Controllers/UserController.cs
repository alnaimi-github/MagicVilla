using System.Net;
using MagicVilla_VillaAPI.Dto.LoginDto;
using MagicVilla_VillaAPI.Dto.RegisterDto;
using MagicVilla_VillaAPI.Dto.ResponseDto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;

[Route("api/v{version:apiVersion}/UserAuth")]
[ApiController]
[AllowAnonymous]
[ApiVersionNeutral]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ApiResponse _response;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _response = new ApiResponse();
    }

    [HttpGet("error")]
    public IActionResult error()
    {
        throw new FileNotFoundException();
    }
    [HttpGet("ImageError")]
    public IActionResult ImageError()
    {
        throw new BadImageFormatException("Fake Image Exception!");
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
    {
        try
        {
            var ifUserNameUnique = _userRepository.IsUniqueUser(registrationRequestDto.UserName);
            if (ifUserNameUnique)
            {
                var registerResponse = await _userRepository.Register(registrationRequestDto);
                if (registerResponse != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = registerResponse;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Error while registering." };
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Username already exists." };
            return BadRequest(_response);
        }
        catch (Exception ex)
        {
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Internal server error." };
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var loginResponse = await _userRepository.Login(loginRequestDto);

        if (loginResponse.AccessToken != null && !string.IsNullOrEmpty(loginResponse.AccessToken))
        {
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        _response.StatusCode = HttpStatusCode.BadRequest;
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { "Username or password is incorrect." };
        return BadRequest(_response);
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> GetNewTokenFromRefreshToken([FromBody] TokenDto tokenDto)
    {
        if (ModelState.IsValid)
        {
            var tokenDtoResponse = await _userRepository.RefreshAccessToken(tokenDto);
            if (tokenDtoResponse==null|| string.IsNullOrEmpty(tokenDtoResponse.AccessToken))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = ["Token Invalid."];
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = tokenDtoResponse;
            return Ok(_response);
        }
        else
        {
            _response.IsSuccess = false;
            _response.StatusCode=HttpStatusCode.BadRequest;
            _response.Result = "Invalid input";
            return BadRequest(_response);
        }

    }

    [HttpPost("RevokeRefreshToken")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] TokenDto tokenDto)
    {
        if (ModelState.IsValid)
        {
            await _userRepository.RevokeRefreshToken(tokenDto);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        _response.StatusCode = HttpStatusCode.BadRequest;
        _response.IsSuccess = false;
        _response.ErrorMessages = ["Invalid Input."];
        return BadRequest(_response);

    }


}