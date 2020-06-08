using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;

            _httpContextAccessor = httpContextAccessor;

            Task.Run(() => this.SetAccessToken(_httpClient)).Wait();
        }

        protected async Task SetAccessToken(HttpClient httpClient )
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
            //To look it the accessToken go to https://jwt.io/ and paste it into there.
        }
    }
}