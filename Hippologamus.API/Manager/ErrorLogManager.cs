using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using Hippologamus.DTO.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class ErrorLogManager : BaseManager, IErrorLogManager
    {
        private readonly IDetailLogService _detailLogService;

        public ErrorLogManager(IDetailLogService detailLogService, IMapper mapper)
            : base(mapper)
        {
            _detailLogService = detailLogService;
        }

        public async Task<PagedList<ErrorLogCollection>> GetAllError(ErrorLogCollectionSearch errorLogDisplaySearch)
        {
            var perfLogFromRepo = await _detailLogService.GetAllErrors(errorLogDisplaySearch);
            var errorLogs = _mapper.Map<List<ErrorLogCollection>>(perfLogFromRepo);
            var result = PagedList<ErrorLogCollection>.Create(errorLogs, errorLogDisplaySearch.PageNumber, errorLogDisplaySearch.PageSize);
            return result;
        }
    }
}
