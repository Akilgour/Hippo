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

            arrangeContext.Add(new PerfLog() {Id = 1, ElapsedMilliseconds = "50", MachineName = "PC-A", TimeStamp = new DateTime(2020, 1, 1), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() {Id = 2, ElapsedMilliseconds = "60", MachineName = "PC-B", TimeStamp = new DateTime(2020, 1, 2), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() {Id = 3, ElapsedMilliseconds = "51", MachineName = "PC-C", TimeStamp = new DateTime(2020, 1, 3), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() {Id = 4, ElapsedMilliseconds = "61", MachineName = "PC-A", TimeStamp = new DateTime(2020, 1, 4), PerfItem = "PerfLogs-GetById", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() {Id = 5, ElapsedMilliseconds = "52", MachineName = "PC-B", TimeStamp = new DateTime(2020, 1, 5), PerfItem = "PerfLogs-Get", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new PerfLog() {Id = 6, ElapsedMilliseconds = "62", MachineName = "PC-C", TimeStamp = new DateTime(2020, 1, 6), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
            arrangeContext.Add(new PerfLog() {Id = 7, ElapsedMilliseconds = "53", MachineName = "PC-A", TimeStamp = new DateTime(2020, 1, 7), PerfItem = "Beatle-Get", Assembly = "Demo.API" });
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

        [Fact]
        public async Task GetAll_Search_OrderByTimeStampOrderAscending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
               OrderBy = "TimeStamp",
               OrderAscending = true
            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(1, value[0].Id);
            Assert.Equal(2, value[1].Id);
            Assert.Equal(3, value[2].Id);
            Assert.Equal(4, value[3].Id);
            Assert.Equal(5, value[4].Id);
            Assert.Equal(6, value[5].Id);
            Assert.Equal(7, value[6].Id);
        }

        [Fact]
        public async Task GetAll_Search_OrderByTimeStampOrderDescending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                OrderBy = "TimeStamp",
                OrderAscending = false

            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(7, value[0].Id);
            Assert.Equal(6, value[1].Id);
            Assert.Equal(5, value[2].Id);
            Assert.Equal(4, value[3].Id);
            Assert.Equal(3, value[4].Id);
            Assert.Equal(2, value[5].Id);
            Assert.Equal(1, value[6].Id);
        }


        [Fact]
        public async Task GetAll_Search_OrderByMachineNameOrderAscending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                OrderBy = "MachineName",
                OrderAscending = true

            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(1, value[0].Id);
            Assert.Equal(4, value[1].Id);
            Assert.Equal(7, value[2].Id);
            Assert.Equal(2, value[3].Id);
            Assert.Equal(5, value[4].Id);
            Assert.Equal(3, value[5].Id);
            Assert.Equal(6, value[6].Id);
        }

        [Fact]
        public async Task GetAll_Search_OrderByMachineNameOrderDescending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                OrderBy = "MachineName",
                OrderAscending = false

            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(3, value[0].Id);
            Assert.Equal(6, value[1].Id);
            Assert.Equal(2, value[2].Id);
            Assert.Equal(5, value[3].Id);
            Assert.Equal(1, value[4].Id);
            Assert.Equal(4, value[5].Id);
            Assert.Equal(7, value[6].Id);
        }

        [Fact]
        public async Task GetAll_Search_OrderByElapsedMillisecondsOrderAscending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                OrderBy = "ElapsedMilliseconds",
                OrderAscending = true

            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(1, value[0].Id);
            Assert.Equal(3, value[1].Id);
            Assert.Equal(5, value[2].Id);
            Assert.Equal(7, value[3].Id);
            Assert.Equal(2, value[4].Id);
            Assert.Equal(4, value[5].Id);
            Assert.Equal(6, value[6].Id);
        }

        [Fact]
        public async Task GetAll_Search_OrderByElapsedMillisecondsOrderDescending()
        {
            //arrange
            var perfLogRepository = new PerfLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var perfLogDisplaySearch = new PerfLogCollectionSearch()
            {
                OrderBy = "ElapsedMilliseconds",
                OrderAscending = false

            };
            //act
            var value = await perfLogRepository.GetAll(perfLogDisplaySearch);
            //assert
            Assert.Equal(6, value[0].Id);
            Assert.Equal(4, value[1].Id);
            Assert.Equal(2, value[2].Id);
            Assert.Equal(7, value[3].Id);
            Assert.Equal(5, value[4].Id);
            Assert.Equal(3, value[5].Id);
            Assert.Equal(1, value[6].Id);
        }
    }
}