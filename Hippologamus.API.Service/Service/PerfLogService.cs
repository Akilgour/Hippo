using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class PerfLogService : IPerfLogService
    {
        private readonly IPerfLogRepository _perfLogRepository;

        public PerfLogService(IPerfLogRepository perfLogRepository)
        {
            _perfLogRepository = perfLogRepository;
        }

        public async Task<List<PerfLog>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch)
        {
            return await _perfLogRepository.GetAll(perfLogDisplaySearch);
        }

        public async Task<PerfLog> GetById(int perfLogId)
        {
            return await _perfLogRepository.GetById(perfLogId);
        }

        public async Task<bool> Any(int perfLogId)
        {
            return await _perfLogRepository.Any(perfLogId);
        }

        public async Task Delete(int perfLogId)
        {
              await _perfLogRepository.Delete(perfLogId);
        }
    }
}