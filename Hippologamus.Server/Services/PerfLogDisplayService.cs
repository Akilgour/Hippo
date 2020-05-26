using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<IEnumerable<PerfLogDisplay>> PerfLogDisplaySearch(PerfLogDisplaySearch search)
        {
            var searchJson =
                new StringContent(JsonSerializer.Serialize(search), Encoding.UTF8, "application/json");

            //    var response = await _httpClient.GetStreamAsync($"api/PerfLogs/{searchJson}");

            //var client = new RestClient("api/PerfLogs?Assembly=Hippologamus.API");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

          

            //return await JsonSerializer.DeserializeAsync<IEnumerable<PerfLogDisplay>>
            //   (await _httpClient.GetStreamAsync($"api/PerfLogs?{searchJson}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //  var foo = await _httpClient.GetStreamAsync("api/PerfLogs?Assembly=Hippologamus.API");

            //    var bar = await _httpClient.GetAsync("api/PerfLogs?Assembly=Hippologamus.API");

            return await JsonSerializer.DeserializeAsync< IEnumerable<PerfLogDisplay>>
                        (await _httpClient.GetStreamAsync($"api/PerfLogs?Assembly=Hippologamus.API&RequestPath=%2Fapi%2FPerfLogAssembly"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
         
            
        }
    }

}
