﻿using Hippologamus.Shared.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowSecondEllipsisTest
    {
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 10, true)]
        [InlineData(9, 10, true)]
        [InlineData(10, 10, false)]
        public void Resolve(int currentPage, int totalPages, bool expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage, TotalPages = totalPages };
            //act
            var value = SetShowSecondEllipsis.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}