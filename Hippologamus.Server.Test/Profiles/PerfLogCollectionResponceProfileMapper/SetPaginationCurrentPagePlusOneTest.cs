using Hippologamus.DTO.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetPaginationCurrentPagePlusOneTest
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(10, 11)]
        public void Resolve(int currentPage, int expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage };
            //act
            var value = SetPaginationCurrentPagePlusOne.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}