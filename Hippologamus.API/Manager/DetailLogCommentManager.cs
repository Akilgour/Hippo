using AutoMapper;
using Hippologamus.API.Factory;
using Hippologamus.API.Manager.Interface;
using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager
{
    public class DetailLogCommentManager : BaseManager, IDetailLogCommentManager
    {
        private readonly IDetailLogCommentService _detailLogCommentService;
        private readonly IDetailLogService _detailLogService;

        public DetailLogCommentManager(IDetailLogCommentService detailLogCommentService, IDetailLogService detailLogService, IMapper mapper)
            : base(mapper)
        {
            _detailLogCommentService = detailLogCommentService;
            _detailLogService = detailLogService;
        }

        public async Task CreateDetailLogComent(DetailLogCommentCreate detailLogCommentCreate, int detailLogId)
        {
            await _detailLogCommentService.CreateDetailLogComent(DetailLogCommentCreateFactory.Create(_mapper.Map<DetailLogComment>(detailLogCommentCreate), detailLogId));
        }


        public async Task<bool> AnyDetailLog(int detailLogId)
        {
         return   await _detailLogService.Any(detailLogId);
        }
    }
}