using Hippologamus.DTO.DTO;
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
                var searchJson =
                new StringContent(JsonSerializer.Serialize(search), Encoding.UTF8, "application/json");
        
            //var foo = await JsonSerializer.DeserializeAsync<PerfLogDisplayRoot>
            //            (await _httpClient.GetStreamAsync($"api/PerfLogs?Assembly=Hippologamus.API&RequestPath=%2Fapi%2FPerfLogAssembly" ), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var properties = from p in search.GetType().GetProperties()
                             where p.GetValue(search, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(search, null).ToString());

                       
            string queryString = String.Join("&", properties.ToArray());


            var result = await _httpClient.GetAsync($"api/PerfLogs?{queryString}");


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