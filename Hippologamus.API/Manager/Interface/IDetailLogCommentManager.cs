using Hippologamus.Shared.DTO;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IDetailLogCommentManager
    {
        Task CreateDetailLogComent(DetailLogCommentCreate detailLogCommentCreate, int detailLogId);
    }
}