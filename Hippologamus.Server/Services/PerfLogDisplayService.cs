using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
                var searchJson =
                new StringContent(JsonSerializer.Serialize(search), Encoding.UTF8, "application/json");

                return await JsonSerializer.DeserializeAsync<PerfLogDisplayRoot>
                            (await _httpClient.GetStreamAsync($"api/PerfLogs?Assembly=Hippologamus.API&RequestPath=%2Fapi%2FPerfLogAssembly"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}