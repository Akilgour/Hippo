using Hippologamus.Shared.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class ErrorLogService : BaseService, IErrorLogService
    {
      

        public ErrorLogService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<ErrorLogCollectionResponce> Search(ErrorLogCollectionSearch search)
        {
          

            var response = await _httpClient.GetAsync($"api/ErrorLog?{ObjectToURLStringFactory.Create(search)}");
            return await ConvertResponseToErrorLogCollectionResponce(response);
        }
        public async Task<ErrorLogCollectionResponce> GetByLink(string link)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(link);
            return await ConvertResponseToErrorLogCollectionResponce(response);
        }

        private static async Task<ErrorLogCollectionResponce> ConvertResponseToErrorLogCollectionResponce(HttpResponseMessage response)
        {
            var result = await JsonSerializer.DeserializeAsync<ErrorLogCollectionResponce>
                        (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            result.Pagination = PaginationFromHeadersFactory.Get(response);
            return result;
        }

    }
}