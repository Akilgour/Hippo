using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys;
using Hippologamus.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Repositorys
{
    public class DetailLogCommentsRepositoryTest
    {
        private readonly HippologamusContext _context;

        public DetailLogCommentsRepositoryTest()
        {
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);
            _context = new HippologamusContext(option);
        }

        [Fact]
        public async Task GetAllErrors()
        {
            //arrange
            var detailLogCommentsRepository = new DetailLogCommentsRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var detailLogComment = new DetailLogComment();

            //act
            await detailLogCommentsRepository.CreateDetailLogComent(detailLogComment);
            //assert
            Assert.Equal(1, _context.DetailLogComments.Count());
        }
    }
}