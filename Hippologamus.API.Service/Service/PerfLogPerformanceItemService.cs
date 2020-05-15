using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class PerfLogPerformanceItemService : IPerfLogPerformanceItemService
    {
        private readonly IPerfLogPerformanceItemRepository _perfLogPerformanceItemRepository;

        public PerfLogPerformanceItemService(IPerfLogPerformanceItemRepository perfLogPerformanceItemRepository)
        {
            _perfLogPerformanceItemRepository = perfLogPerformanceItemRepository ?? throw new ArgumentNullException(nameof(perfLogPerformanceItemRepository));
        }

        public Task<List<PerfLogPerformanceItem>> GetByAssembly(string perfLogAssembly)
        {
            return _perfLogPerformanceItemRepository.GetByAssembly(perfLogAssembly);
        }
    }
}