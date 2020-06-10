using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IDetailLogCommentService
    {
        Task Add(DetailLogCommentCreate detailLogCommentCreate, int detailLogId);

        Task<IEnumerable<DetailLogCommentCollection>> Get(int detailLogId);
        Task<DetailLogCommentDetails> Get(int detailLogId, int detailLogCommentId);
        Task Update(DetailLogCommentCreate detailLogCommentCreate, int detailLogId);
    }
}