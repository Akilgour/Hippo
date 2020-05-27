using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogAssemblyService : BaseService, IPerfLogAssemblyService
    {
        public PerfLogAssemblyService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<IEnumerable<PerfLogAssemblyCollection>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PerfLogAssemblyCollection>>
                (await _httpClient.GetStreamAsync($"api/PerfLogAssembly"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
