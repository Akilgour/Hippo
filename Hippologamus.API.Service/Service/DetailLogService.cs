using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class DetailLogService : IDetailLogService
    {
        private readonly IDetailLogRepository _detailLogRepository;

        public DetailLogService(IDetailLogRepository detailLogRepository)
        {
            _detailLogRepository = detailLogRepository;
        }

        public Task<List<DetailLog>> GetAll()
        {
            return _detailLogRepository.GetAll();
        }

        public async Task<List<DetailLog>> GetAllErrors(ErrorLogCollectionSearch errorLogDisplaySearch)
        {
            return await _detailLogRepository.GetAllErrors(errorLogDisplaySearch);
        }

        public async Task<bool> Any(int id)
        {
            return await _detailLogRepository.Any(id);
        }
    }
}