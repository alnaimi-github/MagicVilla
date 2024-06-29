using static MagicVilla_Utility.StaticDetails.Sd;
namespace MagicVilla_Web.Dto.RequestDto;

public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.Get;
    public ContentType ContentType { get; set; } = ContentType.Json;
    public string ApiUrl { get; set; } = string.Empty;
    public object? Data { get; set; }
}