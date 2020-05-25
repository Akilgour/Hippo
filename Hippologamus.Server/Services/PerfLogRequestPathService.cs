using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogRequestPathService : BaseService, IPerfLogRequestPathService
    {
        public PerfLogRequestPathService(HttpClient httpClient)
          : base(httpClient)
        {
        }

        public async Task<IEnumerable<PerfLogRequestPathDisplay>> GetPerfLogRequestPaths(string perfLogAssembly)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PerfLogRequestPathDisplay>>
                (await _httpClient.GetStreamAsync($"api/PerfLogRequestPath?perfLogAssembly={perfLogAssembly}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}