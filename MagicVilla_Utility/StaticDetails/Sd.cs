namespace MagicVilla_Utility.StaticDetails;

public static class Sd
{
    public const string AccessToken = "JWTToken";
    public const string RefreshToken = "RefreshToken";
    public const string CurrentApiVersion = "v2";

    public enum Roles
    {
        Admin,
        Customer
    }

    public enum ApiType
    {
        Get,
        Post,
        Put,
        Delete,
        Patch
    }

    public enum ContentType
    {
        Json,
        MultipartFormData
    }
}