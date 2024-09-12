using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TvMazeApi.Interfaces.Authentication;
using TvMazeApi.Utils;

namespace TvMazeApi.Authentication
{
    public class ApiKeyAuthFilter(IApiKeyValidation apiKeyValidation) : IAuthorizationFilter
    {
        private readonly IApiKeyValidation _apikeyValidation = apiKeyValidation;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var requestApiKey = context.HttpContext.Request.Headers[Constants.ApiKeyHeaderName];

            if (String.IsNullOrEmpty(requestApiKey)) 
            {
                context.Result = new BadRequestResult();

                return;
            }

            if (!_apikeyValidation.IsValidApiKey(requestApiKey)) 
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
