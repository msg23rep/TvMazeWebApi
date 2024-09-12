using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Authentication;

namespace TvMazeApi.Attributes
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}
