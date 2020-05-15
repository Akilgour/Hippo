using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys;
using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Repositorys
{
    public class PerfLogPerformanceItemRepositoryTest
    {
        private readonly HippologamusContext _context;

        public PerfLogPerformanceItemRepositoryTest()
        {
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);

            arrangeContext.Add(new PerfLog() { PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "PerfLogs-Get", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.SaveChanges();
            _context = new HippologamusContext(option);
        }

        [Theory]
        [InlineData("Demo.API", 1)]
        [InlineData("Hippologamus.API", 2)]
        [InlineData("NotUsed", 0)]
        public async Task GetAll_Count(string assembly, int expected)
        {
            //arrange
            //Done in constructor

            var perfLogPerformanceItemRepository = new PerfLogPerformanceItemRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            //act
            var value = await perfLogPerformanceItemRepository.GetByAssembly(assembly);
            //assert
            Assert.Equal(expected, value.Count());
        }


        [Fact]
        public async Task GetAll_DemoAPI()
        {
            //arrange
            //Done in constructor

            var perfLogPerformanceItemRepository = new PerfLogPerformanceItemRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            //act
            var value = await perfLogPerformanceItemRepository.GetByAssembly("Demo.API");
            //assert
            Assert.Equal("Beatle-Get", value[0].PerformanceItem);
            Assert.Equal("Demo.API", value[0].Assembly);
        }

        [Theory]
        [InlineData("PerfLogs-Get", 0)]
        [InlineData("PerfLogs-GetById", 1)]
        public async Task GetAll_HippologamusAPI(string performanceItem, int index)
        {
            //arrange
            //Done in constructor

            var perfLogPerformanceItemRepository = new PerfLogPerformanceItemRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            //act
            var value = await perfLogPerformanceItemRepository.GetByAssembly("Hippologamus.API");
            //assert
            Assert.Equal(performanceItem, value[index].PerformanceItem);
            Assert.Equal("Hippologamus.API", value[index].Assembly);
        }
    }
}