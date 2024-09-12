namespace TvMazeApi.Interfaces.Authentication
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string requestApiKey);
    }
}
