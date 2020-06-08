using Hippologamus.Domain.Models;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IDetailLogCommentsRepository
    {
        Task CreateDetailLogComent(DetailLogComment detailLogComment);
    }
}
