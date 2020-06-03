using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class PerfLogRequestPathService : IPerfLogPerfItemService
    {
        private readonly IPerfLogRequestPathRepository _perfLogRequestPathRepository;

        public PerfLogRequestPathService(IPerfLogRequestPathRepository perfLogRequestPathRepository)
        {
            _perfLogRequestPathRepository = perfLogRequestPathRepository ?? throw new ArgumentNullException(nameof(perfLogRequestPathRepository));
        }

        public Task<List<PerfLogPerfItem>> GetByAssembly(string perfLogAssembly)
        {
            return _perfLogRequestPathRepository.GetByAssembly(perfLogAssembly);
        }
    }
}