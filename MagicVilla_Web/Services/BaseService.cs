using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using MagicVilla_Utility.StaticDetails;
using MagicVilla_Web.Dto.LoginDto;
using MagicVilla_Web.Dto.RequestDto;
using MagicVilla_Web.Dto.ResponseDto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using static MagicVilla_Utility.StaticDetails.Sd;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public ApiResponse? ResponseModel { get; set; }
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenProvider _tokenProvider;
        private readonly string _villaUrl;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IApiMessageRequestBuilder _apiMessageRequestBuilder;

        public BaseService(IHttpClientFactory clientFactory, ITokenProvider tokenProvider,IConfiguration config, IHttpContextAccessor contextAccessor, IApiMessageRequestBuilder apiMessageRequestBuilder)
        {
            _clientFactory = clientFactory;
            _tokenProvider = tokenProvider;
            _contextAccessor = contextAccessor;
            _apiMessageRequestBuilder = apiMessageRequestBuilder;
            this.ResponseModel = new ApiResponse();
            _villaUrl = config.GetValue<string>("ServiceUrls:VillaApi")!;
        }

        #region SendAsync<T>

        public async Task<T> SendAsync<T>(ApiRequest apiRequest , bool withBearer = true)
        {
            try
            {
                var client = _clientFactory.CreateClient("MagicVillaApi");
                var messageFactory = () => _apiMessageRequestBuilder.Build(apiRequest);
               
                HttpResponseMessage httpResponseMessage = null!;
                httpResponseMessage = await SendWithRefreshTokenAsync(client,messageFactory,withBearer);

                ApiResponse finalApiResponse = new() { IsSuccess = false };
                try
                {
                    switch (httpResponseMessage.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            finalApiResponse.ErrorMessages = ["Not Found!"];
                            break;
                        case HttpStatusCode.Unauthorized:
                            finalApiResponse.ErrorMessages = ["Unauthorized ('_')"];
                            break;
                        case HttpStatusCode.Forbidden:
                            finalApiResponse.ErrorMessages = ["Access Denied"];
                            break;
                        case HttpStatusCode.InternalServerError:
                            finalApiResponse.ErrorMessages = ["Internal Server Error !"];
                            break;
                        default:
                            var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
                            finalApiResponse.IsSuccess = true;
                            finalApiResponse = JsonConvert.DeserializeObject<ApiResponse>(apiContent)!;
                            break;
                    }
                }
                catch (Exception e)
                {
                    finalApiResponse.ErrorMessages = ["Error Encountered",$"{e.Message}"];
                }
                var serializeApiResponse = JsonConvert.SerializeObject(finalApiResponse);
                var deserializeResponse = JsonConvert.DeserializeObject<T>(serializeApiResponse);
                return deserializeResponse!;
            }
            catch (AuthException)
            {
                throw;
            }
            catch (Exception e)
            {
                var dto = new ApiResponse()
                {
                    ErrorMessages = [e.Message],
                    IsSuccess = false,

                };
                var res = JsonConvert.SerializeObject(dto);
                var response = JsonConvert.DeserializeObject<T>(res);
                return response!;
            }


        }

        #endregion

        #region SendWithRefreshTokenAsync

        private async Task<HttpResponseMessage> SendWithRefreshTokenAsync(HttpClient httpClient,
            Func<HttpRequestMessage>httpRequestMessageFactory, bool withBearer = true)
        {
            if (!withBearer)
            {
                return await httpClient.SendAsync(httpRequestMessageFactory());
            }
            else
            {
                var tokenDto = _tokenProvider.GetToken();
                if (tokenDto!=null&&!string.IsNullOrEmpty(tokenDto.AccessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", tokenDto.AccessToken);
                }

                try
                {
                    var response = await httpClient.SendAsync(httpRequestMessageFactory());
                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    }
                    // If this fails then we can pass refresh token!
                    else
                    {
                        if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            // Generate new token from refresh token / Sign in with that new token and then retry
                            await InvokeRefreshTokenEndpoint(httpClient, tokenDto!);
                            response = await httpClient.SendAsync(httpRequestMessageFactory());
                            return response;
                        }
                    }

                    return response;
                }
                catch (AuthException)
                {
                    throw;
                }
                catch (HttpRequestException httpRequestException)
                {
                    if (httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Refresh token and retry the request
                        await InvokeRefreshTokenEndpoint(httpClient, tokenDto!);
                        return await httpClient.SendAsync(httpRequestMessageFactory());
                    }
                    throw;
                }
            }

        }

        #endregion

        #region InvokeRefreshTokenEndpoint

        private async Task InvokeRefreshTokenEndpoint(HttpClient httpClient,TokenDto tokenDto)
        {
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri($"{_villaUrl}/api/{Sd.CurrentApiVersion}/UserAuth/RefreshToken");
            message.Method=HttpMethod.Post;
            message.Content = new StringContent(JsonConvert.SerializeObject(new TokenDto()
            {
                AccessToken = tokenDto.AccessToken,
                RefreshToken = tokenDto.RefreshToken,
            }),Encoding.UTF8, "application/json");
            
            var response= await httpClient.SendAsync(message);
            var content=await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
            if (apiResponse!.IsSuccess != true)
            {
                await _contextAccessor.HttpContext!.SignOutAsync();
                _tokenProvider.ClearToken();
                throw new AuthException();
            }
            else
            {
                var tokenDataString = JsonConvert.SerializeObject(apiResponse.Result);
                var tokenDtoObj = JsonConvert.DeserializeObject<TokenDto>(tokenDataString);
                if (tokenDtoObj!=null && !string.IsNullOrEmpty(tokenDtoObj.AccessToken))
                {
                 // New method to sign in with the new token that receive
                 await SignInWithNewTokens(tokenDtoObj);
                 httpClient.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Bearer", tokenDtoObj.AccessToken);
                }
            }

        }
        #endregion


        #region SignInWithNewTokens

        private async Task SignInWithNewTokens(TokenDto tokenDto)
        {
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
            await _contextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            _tokenProvider.SetToken(tokenDto);
        }

        #endregion

      
    }
}