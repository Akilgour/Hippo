using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogPerfItemService : BaseService, IPerfLogPerfItemService
    {
        public PerfLogPerfItemService(HttpClient httpClient)
          : base(httpClient)
        {
        }

        public async Task<IEnumerable<PerfLogPerfItemCollection>> GetPerfLogPerfItems(string perfLogAssembly)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PerfLogPerfItemCollection>>
                (await _httpClient.GetStreamAsync($"api/PerfLogPerfItem?perfLogAssembly={perfLogAssembly}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}