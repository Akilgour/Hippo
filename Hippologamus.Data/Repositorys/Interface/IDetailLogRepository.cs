using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Data.Repositorys.Interface
{
    public interface IDetailLogRepository
    {
        Task<List<DetailLog>> GetAll();
        Task<List<DetailLog>> GetAllErrors(ErrorLogCollectionSearch errorLogDisplaySearch);
      
    }
}