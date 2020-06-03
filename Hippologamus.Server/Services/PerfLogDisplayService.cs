using Hippologamus.DTO.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogDisplayService : BaseService, IPerfLogDisplayService
    {
        public PerfLogDisplayService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<PerfLogCollectionResponce> GetByLink(string link)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(link);
            return await ConvertResponseToPerfLogCollectionResponce(response);
        }         

        public async Task<PerfLogCollectionResponce> PerfLogDisplaySearch(PerfLogCollectionSearch search)
        {
            var response = await _httpClient.GetAsync($"api/PerfLogs?{ObjectToURLStringFactory.Create(search)}");
            return await ConvertResponseToPerfLogCollectionResponce(response);
        }

        public  async Task DeleteById(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/PerfLogs/{id}");
        }

        private static async Task<PerfLogCollectionResponce> ConvertResponseToPerfLogCollectionResponce(HttpResponseMessage response)
        {
            var result = await JsonSerializer.DeserializeAsync<PerfLogCollectionResponce>
                            (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            result.Pagination = PaginationFromHeadersFactory.Get(response);
            return result;
        }
    }
}