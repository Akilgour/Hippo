using Hippologamus.Shared.DTO;
using System.Threading.Tasks;

namespace Hippologamus.Server.Services.Interface
{
    public interface IDetailLogCommentService
    {
        Task Add(DetailLogCommentCreate detailLogCommentCreate, int detailLogId);
    }
}
