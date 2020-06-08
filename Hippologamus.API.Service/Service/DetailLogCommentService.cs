using Hippologamus.API.Service.Service.Interface;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
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
    }
}