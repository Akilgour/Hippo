﻿using Hippologamus.API.Service.Service;
using Hippologamus.Data.Repositorys.Interface;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.API.Service.Test.Service
{
    public class PerfLogServiceTest
    {
        [Fact]
        public async Task GetAll()
        {
            //arrange
            var repository = new Mock<IPerfLogRepository>();
            var perfLogs = new List<PerfLog>
            {
                new PerfLog(),
                new PerfLog(),
                new PerfLog(),
                new PerfLog(),
                new PerfLog()
            };
            repository.Setup(x => x.GetAll(It.IsAny<PerfLogCollectionSearch>())).Returns(Task.FromResult(perfLogs));
            var perfLogService = new PerfLogService(repository.Object);
            //act
            var actual = await perfLogService.GetAll(new PerfLogCollectionSearch());
            //assert
            Assert.Equal(5, actual.Count());
        }
    }
}