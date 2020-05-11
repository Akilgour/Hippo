using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys;
using Hippologamus.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Repositorys
{
    public class PerfLogRepositoryTest
    {
        [Fact]
        public async Task GetAll()
        {
            //arrange
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);

            arrangeContext.Add(new PerfLog());
            arrangeContext.Add(new PerfLog());
            arrangeContext.Add(new PerfLog());
            arrangeContext.Add(new PerfLog());
            arrangeContext.Add(new PerfLog());
            arrangeContext.SaveChanges();

            var context = new HippologamusContext(option);
            var perfLogRepository = new PerfLogRepository(context);
            //act
            var value = await perfLogRepository.GetAll();
            //assert
            Assert.Equal(5, value.Count());
        }
    }
}
