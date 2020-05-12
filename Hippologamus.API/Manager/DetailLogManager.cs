using AutoMapper;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class DetailLogManager : BaseManager, IDetailLogManager
    {
        private readonly IDetailLogService _perfLogService;

        public DetailLogManager(IDetailLogService perfLogService, IMapper mapper)
            : base(mapper)
        {
            _perfLogService = perfLogService;
        }

        public async Task<List<DetailLogDisplay>> GetAll()
        {
            return _mapper.Map<List<DetailLogDisplay>>(await _perfLogService.GetAll());
        }
    }
}