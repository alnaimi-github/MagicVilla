using MagicVilla_Web.Dto.RequestDto;
using MagicVilla_Web.Dto.ResponseDto;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse? ResponseModel  { get; set; }
        Task<T>SendAsync<T>(ApiRequest apiRequest, bool withBearer = true);
    }
}
