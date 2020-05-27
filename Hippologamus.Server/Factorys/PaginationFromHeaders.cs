using Hippologamus.DTO.DTO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Hippologamus.Server.Factorys
{
    public static class PaginationFromHeaders
    {
        public static PaginationHeader Get(HttpResponseMessage response)
        {
            var pagination = response.Headers.GetValues("X-Pagination").First();

            return JsonSerializer.Deserialize<PaginationHeader>
                            (pagination, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}