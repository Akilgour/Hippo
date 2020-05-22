using System.Net.Http;

namespace Hippologamus.Server.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}