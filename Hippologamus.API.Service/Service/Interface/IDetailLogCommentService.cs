using Hippologamus.Domain.Models;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IDetailLogCommentService
    {
        Task CreateDetailLog(DetailLogComment detailLogComment);
    }
}