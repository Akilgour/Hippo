using Hippologamus.Server.Services.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class PerfLogAssemblyService : BaseService, IPerfLogAssemblyService
    {
        public PerfLogAssemblyService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<PerfLogAssemblyCollection>> GetAll()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<PerfLogAssemblyCollection>>($"api/PerfLogAssembly");
        }
    }
}