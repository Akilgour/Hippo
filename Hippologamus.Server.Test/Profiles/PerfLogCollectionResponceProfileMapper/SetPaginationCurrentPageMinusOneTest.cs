using Hippologamus.Shared.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetPaginationCurrentPageMinusOneTest
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(10, 9)]
        public void Resolve(int currentPage, int expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage };
            //act
            var value = SetPaginationCurrentPageMinusOne.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}