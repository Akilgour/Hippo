using Hippologamus.Data.Context;
using Hippologamus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Hippologamus.Data.Repositorys;
using Hippologamus.DTO.DTO;

namespace Hippologamus.Data.Test.Repositorys
{
    public class DetailLogRepositoryTest_GetAllErrors
    {
        private readonly HippologamusContext _context;

        public DetailLogRepositoryTest_GetAllErrors()
        {
            var option = DbContextOptionsBuilderFactory.Create();
            var arrangeContext = new HippologamusContext(option);

            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 1), Level = "Error", RequestPath = "/api/beatle", Assembly = "Demo.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 2), Level = "Error", RequestPath = "/api/PerfLogs", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 3), Level = "Error", RequestPath = "/api/PerfLogs", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 4), Level = "Error", RequestPath = "/api/PerfLogs", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 5), Level = "Information", RequestPath = "/api/PerfLogs", Assembly = "Hippologamus.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 6), Level = "Error", RequestPath = "/api/beatle/2", Assembly = "Demo.API" });
            arrangeContext.Add(new DetailLog() { TimeStamp = new DateTime(2020, 1, 7), Level = "Error", RequestPath = "/api/beatle", Assembly = "Demo.API" });
            arrangeContext.SaveChanges();
            _context = new HippologamusContext(option);
        }

        [Fact]
        public async Task GetAllErrors()
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch();
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(6, value.Count());
        }

        [Theory]
        [InlineData("/api/beatle", 2)]
        [InlineData("/api/beatle/2", 1)]
        [InlineData("/api/PerfLogs", 3)]
        [InlineData("NotUsed", 0)]
        public async Task GetAllErrors_RequestPath_Count(string requestPath, int expected)
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                RequestPath = requestPath
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("Demo.API", 3)]
        [InlineData("Hippologamus.API", 3)]
        [InlineData("NotUsed", 0)]
        public async Task GetAllErrors_Assembly_Count(string assembly, int expected)
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                Assembly = assembly
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("Demo.API" , "/api/beatle", 2)]
        [InlineData("Demo.API" , "/api/beatle/2", 1)]
        [InlineData("Hippologamus.API" , "/api/PerfLogs", 3)]
        [InlineData("Hippologamus.API" , "NotUsed", 0)]
        public async Task GetAllErrors_AssemblyRequestPathSearch_Count(string assembly, string requestPath, int expected)
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                Assembly = assembly ,
                RequestPath = requestPath
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("2020/01/01", 6)]
        [InlineData("2020/01/02", 5)]
        [InlineData("2020/01/03", 4)]
        [InlineData("2020/01/04", 3)]
        [InlineData("2020/01/05", 2)]
        [InlineData("2020/01/06", 2)]
        [InlineData("2020/01/07", 1)]
        [InlineData("2020/01/08", 0)]
        public async Task GetAllErrors_DateFromSearch_Count(string dateFrom, int expected)
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                DateFrom = DateTime.Parse(dateFrom)
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Theory]
        [InlineData("2020/01/01", 1)]
        [InlineData("2020/01/02", 2)]
        [InlineData("2020/01/03", 3)]
        [InlineData("2020/01/04", 4)]
        [InlineData("2020/01/05", 4)]
        [InlineData("2020/01/06", 5)]
        [InlineData("2020/01/07", 6)]
        public async Task GetAllErrors_DateToSearch_Count(string dateTo, int expected)
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                DateTo = DateTime.Parse(dateTo)
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(expected, value.Count());
        }

        [Fact]
        public async Task GetAllErrors_Search_Count()
        {
            //arrange
            var DetailLogRepository = new DetailLogRepository(_context, PollyTestFactory.CreateAsyncRetryPolicy());
            var errorLogDisplaySearch = new ErrorLogDisplaySearch()
            {
                Assembly = "Hippologamus.API",
                DateFrom = new DateTime(2020, 1, 2),
                DateTo = new DateTime(2020, 1, 5)
            };
            //act
            var value = await DetailLogRepository.GetAllErrors(errorLogDisplaySearch);
            //assert
            Assert.Equal(3, value.Count());
        }
    }
}