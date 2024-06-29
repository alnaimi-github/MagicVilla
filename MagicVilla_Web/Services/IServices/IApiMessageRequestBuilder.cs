using MagicVilla_Web.Dto.RequestDto;

namespace MagicVilla_Web.Services.IServices
{
    public interface IApiMessageRequestBuilder
    {
        HttpRequestMessage Build(ApiRequest apiRequest);
    }
}
