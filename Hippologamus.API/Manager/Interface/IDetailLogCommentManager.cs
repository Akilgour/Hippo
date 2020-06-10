using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IDetailLogCommentManager
    {
        Task CreateDetailLogComent(DetailLogCommentCreate detailLogCommentCreate, int detailLogId);
        Task<bool> AnyDetailLog(int detailLogId);
        Task<List<DetailLogCommentCollection>> GetByDetailLogId(int detailLogId);
        Task<DetailLogCommentDetails> GetByDetailLogCommentsId(int detailLogCommentsId);
        Task<bool> Any(int id);
        Task Update(DetailLogCommentUpdate detailLogCommentUpdate);
    }
}