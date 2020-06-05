using Hippologamus.Shared.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowPagePlusOneButtonTest
    {
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 10, true)]
        [InlineData(2, 10, true)]
        [InlineData(8, 10, true)]
        [InlineData(9, 10, false)]
        [InlineData(10, 10, false)]
        public void Resolve(int currentPage, int totalPages, bool expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage, TotalPages = totalPages };
            //act
            var value = SetShowPagePlusOneButton.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}