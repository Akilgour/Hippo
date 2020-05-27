using Hippologamus.Data.Context;
using Hippologamus.Data.Repositorys;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Repositorys
{
    public class PerfLogRepositoryTest
    {
        private readonly HippologamusContext _context;

        public PerfLogRepositoryTest()
        {
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);

            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 1), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 2), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 3), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 4), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 5), PerfItem = "PerfLogs-Get", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 6), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() { TimeStamp = new DateTime(2020, 1, 7), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.SaveChanges();
            _context = new HippologamusContext(option);
        }

        [Fact]
        public async Task GetAll()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch();
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(7, value.Count());
        }

        [Theory]
        [InlineData("Demo.API", 3)]
        [InlineData("Hippologamus.API", 4)]
        [InlineData("NotUsed", 0)]
        public async Task GetAll_AssemblySearch_Count(string assembly, int expected)
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                Assembly = assembly
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("Beatle-Get", 3)]
        [InlineData("PerfLogs-GetById", 3)]
        [InlineData("PerfLogs-Get", 1)]
        public async Task GetAll_PerfItemSearch_Count(string perfItem, int expected)
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                PerfItem = perfItem
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("Demo.API", "Beatle-Get", 3)]
        [InlineData("NotUsed", "Beatle-Get", 0)]
        [InlineData("Demo.API", "NotUsed", 0)]
        [InlineData("Hippologamus.API", "PerfLogs-GetById", 3)]
        [InlineData("NotUsed", "PerfLogs-GetById", 0)]
        [InlineData("Hippologamus.API", "NotUsed", 0)]
        [InlineData("Hippologamus.API", "PerfLogs-Get", 1)]
        [InlineData("NotUsed", "Hippologamus.API", 0)]
        [InlineData("PerfLogs-Get", "NotUsed", 0)]
        public async Task GetAll_AssemblyPerfItemSearch_Count(string assembly, string perfItem, int expected)
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                PerfItem = perfItem,
                Assembly = assembly
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("2020/01/01", 7)]
        [InlineData("2020/01/02", 6)]
        [InlineData("2020/01/03", 5)]
        [InlineData("2020/01/04", 4)]
        [InlineData("2020/01/05", 3)]
        [InlineData("2020/01/06", 2)]
        [InlineData("2020/01/07", 1)]
        [InlineData("2020/01/08", 0)]
        public async Task GetAll_DateFromSearch_Count(string dateFrom, int expected)
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                DateFrom = DateTime.Parse(dateFrom)
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("2020/01/01", 1)]
        [InlineData("2020/01/02", 2)]
        [InlineData("2020/01/03", 3)]
        [InlineData("2020/01/04", 4)]
        [InlineData("2020/01/05", 5)]
        [InlineData("2020/01/06", 6)]
        [InlineData("2020/01/07", 7)]
        public async Task GetAll_DateToSearch_Count(string dateTo, int expected)
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                DateTo = DateTime.Parse(dateTo)
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Fact]
        public async Task GetAll_Search_Count()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                Assembly = "Hippologamus.API",
                DateFrom = new DateTime(2020, 1, 3),
                DateTo = new DateTime(2020, 1, 4)


            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(2, value.Count());
        }
    }
}