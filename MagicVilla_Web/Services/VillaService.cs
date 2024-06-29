using MagicVilla_Utility.StaticDetails;
using MagicVilla_Web.Dto.RequestDto;
using MagicVilla_Web.Dto.Villa;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService :IVillaService
    {
        private readonly IBaseService _baseService;
        private readonly string _villaUrl;
        private const string Url = $"/api/{Sd.CurrentApiVersion}/VillaApi/";

        public VillaService(IConfiguration config, IBaseService baseService)
        {
            _baseService = baseService;
            _villaUrl = config.GetValue<string>("ServiceUrls:VillaApi")!;
        }
       
        public async Task<T> CreateAsync<T>(VillaCreateDto dto)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Post,
                ContentType = Sd.ContentType.MultipartFormData,
                Data = dto,
                ApiUrl = _villaUrl + Url
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Delete,
                ApiUrl = _villaUrl + Url + id
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Get,
                ApiUrl = _villaUrl + Url
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Get,
                ApiUrl = _villaUrl + Url + id
            });
        }

        public async Task<T> UpdateAsync<T>(VillaUpdateDto dto)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Put,
                ContentType = Sd.ContentType.MultipartFormData,
                Data = dto,
                ApiUrl = _villaUrl + Url
            });
        }
    }
}
