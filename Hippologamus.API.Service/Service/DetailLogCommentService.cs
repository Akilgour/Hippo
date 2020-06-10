using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service
{
    public class DetailLogCommentService : IDetailLogCommentService
    {
        private readonly IDetailLogCommentsRepository _detailLogCommentsRepository;

        public DetailLogCommentService(IDetailLogCommentsRepository detailLogCommentsRepository)
        {
            _detailLogCommentsRepository = detailLogCommentsRepository;
        }

        public async Task CreateDetailLogComent(DetailLogComment detailLogComment)
        {
            await _detailLogCommentsRepository.CreateDetailLogComent(detailLogComment);
        }

        public async Task<DetailLogComment> GetByDetailLogCommentsId(int detailLogCommentsId)
        {
            return await _detailLogCommentsRepository.GetByDetailLogCommentsId(detailLogCommentsId);
        }

        public async Task<List<DetailLogComment>> GetByDetailLogId(int detailLogId)
        {
            return await _detailLogCommentsRepository.GetByDetailLogId(detailLogId);
        }

        public async Task Update(DetailLogComment detailLogComment)
        {

            await _detailLogCommentsRepository.Update(detailLogComment);
        }

        public async Task<bool> Any(int id)
        {
            return await _detailLogCommentsRepository.Any(id);
        }
    }
}