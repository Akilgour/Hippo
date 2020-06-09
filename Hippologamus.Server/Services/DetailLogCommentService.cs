using Hippologamus.Server.Services.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services
{
    public class DetailLogCommentService : BaseService, IDetailLogCommentService
    {
        public DetailLogCommentService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
              : base(httpClient, httpContextAccessor)
        {
        }

        public async Task Add(DetailLogCommentCreate detailLogCommentCreate, int detailLogId)
        {
            await _httpClient.PostJsonAsync($"api/DetailLogComment/{detailLogId}", detailLogCommentCreate);
        }

        public async Task<IEnumerable<DetailLogCommentCollection>> Get(int detailLogId)
        {
            return await _httpClient.GetJsonAsync<IEnumerable<DetailLogCommentCollection>>($"api/DetailLogComment/{detailLogId}");
        }
    }
}