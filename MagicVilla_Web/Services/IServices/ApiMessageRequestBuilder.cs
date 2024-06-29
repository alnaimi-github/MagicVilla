using MagicVilla_Web.Dto.RequestDto;
using Newtonsoft.Json;
using System.Text;
using static MagicVilla_Utility.StaticDetails.Sd;

namespace MagicVilla_Web.Services.IServices
{
    public class ApiMessageRequestBuilder: IApiMessageRequestBuilder
    {
        public HttpRequestMessage Build(ApiRequest apiRequest)
        {
            var message = new HttpRequestMessage();

            message.Headers.Add("Accept",
                apiRequest.ContentType == ContentType.MultipartFormData ? "*/*" : "application/json");


            message.RequestUri = new Uri(apiRequest.ApiUrl);
            if (apiRequest.ContentType == ContentType.MultipartFormData)
            {
                var content = new MultipartFormDataContent();
                foreach (var prop in apiRequest.Data!.GetType().GetProperties())
                {
                    var value = prop.GetValue(apiRequest.Data);
                    if (value is FormFile)
                    {
                        var file = (FormFile)value;
                        if (file != null)
                        {
                            content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                        }
                    }
                    else
                    {
                        content.Add(new StringContent(value == null ? "" : value.ToString()!), prop.Name);
                    }
                }

                message.Content = content;
            }
            else
            {
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
            }

            message.Method = ReturnApiType(apiRequest.ApiType);
            return message;
        }

        #region ReturnApiType

        private static HttpMethod ReturnApiType(ApiType type)
        {
            return type switch
            {
                ApiType.Post => HttpMethod.Post,
                ApiType.Put => HttpMethod.Put,
                ApiType.Delete => HttpMethod.Delete,
                ApiType.Patch => HttpMethod.Patch,
                _ => HttpMethod.Get
            };
        }

        #endregion
    }
}
