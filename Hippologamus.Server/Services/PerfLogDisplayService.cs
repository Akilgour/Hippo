using Hippologamus.DTO.DTO;
using Hippologamus.Server.Factorys;
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

        public async Task<PerfLogDisplayRoot> PerfLogDisplaySearch(PerfLogDisplaySearch search)
        {
            var response = await _httpClient.GetAsync($"api/PerfLogs?{ObjectToURLString.Create(search)}");
            var result = await JsonSerializer.DeserializeAsync<PerfLogDisplayRoot>
                            (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            result.PaginationHeader = PaginationFromHeaders.Get(response);
            return result;
        }
    }
}