using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IDetailLogCommentsRepository
    {
        Task CreateDetailLogComent(DetailLogComment detailLogComment);
        Task<List<DetailLogComment>> GetByDetailLogId(int detailLogId);
        Task<DetailLogComment> GetByDetailLogCommentsId(int detailLogCommentsId);
        Task Update(DetailLogComment detailLogComment);
        Task<bool> Any(int id);
    }
}