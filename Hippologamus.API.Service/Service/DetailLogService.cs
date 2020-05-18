using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
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

        public async Task<List<DetailLog>> GetAllErrors(ErrorLogDisplaySearch errorLogDisplaySearch)
        {
            return await _detailLogRepository.GetAllErrors(errorLogDisplaySearch);
        }
    }
}