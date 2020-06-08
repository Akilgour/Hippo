using Hippologamus.Server.Services.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogPerfItemService : BaseService, IPerfLogPerfItemService
    {
        public PerfLogPerfItemService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
          : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<PerfLogPerfItemCollection>> GetPerfLogPerfItems(string perfLogAssembly)
        {
            return await _httpClient.GetJsonAsync<IEnumerable<PerfLogPerfItemCollection>>($"api/PerfLogPerfItem?perfLogAssembly={perfLogAssembly}");
        }
    }
}