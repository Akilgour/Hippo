using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<PerfLog>> GetAll()
        {
            return await _perfLogRepository.GetAll();
        }

        public async Task<PerfLog> GetById(int perfLogId)
        {
            return await _perfLogRepository.GetById(perfLogId);
        }
    }
}