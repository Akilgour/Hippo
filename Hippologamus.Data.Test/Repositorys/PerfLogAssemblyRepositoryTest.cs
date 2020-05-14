using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys;
using Hippologamus.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Repositorys
{
    public class PerfLogAssemblyRepositoryTest
    {
        private readonly HippologamusContext _context;

        public PerfLogAssemblyRepositoryTest()
        {
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);

            arrangeContext.Add(new PerfLog() { Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { Assembly = "a" });
            arrangeContext.SaveChanges();
            _context = new HippologamusContext(option);
        }

        [Fact]
        public async Task GetAll_Count()
        {
            //arrange
            //Done in constructor

            var perfLogAssemblyRepository = new PerfLogAssemblyRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            //act
            var value = await perfLogAssemblyRepository.GetAll();
            //assert
            Assert.Equal(3, value.Count());
        }


        [Theory]
        [InlineData(0, "a")]
        [InlineData(1, "Demo.API")]
        [InlineData(2, "Hippologamus.API")]
        public async Task GetAll(int index, string expected)
        {
            //arrange
            //Done in constructor

            var perfLogAssemblyRepository = new PerfLogAssemblyRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            //act
            var value = await perfLogAssemblyRepository.GetAll();
            //assert
            Assert.Equal(expected, value[index].Assembly);
        }
    }
}