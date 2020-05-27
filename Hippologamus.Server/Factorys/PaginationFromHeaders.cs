using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Hippologamus.Server.Factorys
{
    public static class PaginationFromHeaders
    {
        public static RootPaginationHeader Get(HttpResponseMessage response)
        {
            var pagination = response.Headers.GetValues("X-Pagination").First();

            return JsonSerializer.Deserialize<RootPaginationHeader>
                            (pagination, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}