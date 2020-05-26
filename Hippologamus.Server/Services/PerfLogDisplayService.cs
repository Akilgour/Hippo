using Hippologamus.DTO.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

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
            var result = await _httpClient.GetAsync($"api/PerfLogs?{ObjectToURLString.Create(search)}");


            var pagination = result.Headers.GetValues("X-Pagination").First(); 
            

            var rootPaginationHeader =   JsonSerializer.Deserialize<RootPaginationHeader>
                            (pagination, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            var bar = await JsonSerializer.DeserializeAsync<PerfLogDisplayRoot>
                            (await result.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            bar.PaginationHeader = rootPaginationHeader;
            return bar;
        }
    }
}