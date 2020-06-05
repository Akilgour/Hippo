using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Shared.DTO;
using Hippologamus.DTO.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class PerfLogManager : BaseManager, IPerflogManager
    {
        private readonly IPerfLogService _perfLogService;

        public PerfLogManager(IPerfLogService perfLogService, IMapper mapper)
            : base(mapper)
        {
            _perfLogService = perfLogService;
        }

        public async Task<PagedList<PerfLogCollection>> GetAll(PerfLogCollectionSearch perfLogDisplaySearch)
        {
            var perfLogFromRepo = await _perfLogService.GetAll(perfLogDisplaySearch);
            var teams = _mapper.Map<List<PerfLogCollection>>(perfLogFromRepo);
            var result = PagedList<PerfLogCollection>.Create(teams, perfLogDisplaySearch.PageNumber, perfLogDisplaySearch.PageSize);
            return result;
        }

        public async Task<PerfLogDetails> GetById(int perfLogId)
        {
            return _mapper.Map<PerfLogDetails>(await _perfLogService.GetById(perfLogId));
        }
                
        public async Task<bool> Any(int perfLogId) 
        {
            return  await _perfLogService.Any(perfLogId);
        }

        public async Task Delete(int perfLogId)
        {
              await _perfLogService.Delete(perfLogId);
        }
    }
}