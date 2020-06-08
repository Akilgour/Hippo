using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IDetailLogService
    {
        Task<List<DetailLog>> GetAll();
        Task<List<DetailLog>> GetAllErrors(ErrorLogCollectionSearch errorLogDisplaySearch);
        Task<bool> Any(int id);
    }
}