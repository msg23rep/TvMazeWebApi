using TvMazeApi.Interfaces.Authentication;
using TvMazeApi.Utils;

namespace TvMazeApi.Authentication
{
    public class ApiKeyValidation(IConfiguration configuration) : IApiKeyValidation
    {
        private readonly IConfiguration _configuration = configuration;

        public bool IsValidApiKey(string requestApiKey)
        {
            if (String.IsNullOrEmpty(requestApiKey)) { return false; }

            var apiKey = _configuration.GetValue<string>(Constants.ApiKeyName);

            if(apiKey is not null && apiKey.Equals(requestApiKey)) 
            { 
                return true; 
            }

            return false;
        }
    }
}
