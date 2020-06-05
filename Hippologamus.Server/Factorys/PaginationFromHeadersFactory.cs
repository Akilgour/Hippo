using Hippologamus.Shared.DTO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Hippologamus.Server.Factorys
{
    public static class PaginationFromHeadersFactory
    {
        public static Pagination Get(HttpResponseMessage response)
        {
            var pagination = response.Headers.GetValues("X-Pagination").First();

            return JsonSerializer.Deserialize<Pagination>
                            (pagination, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}