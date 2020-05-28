using Hippologamus.DTO.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowFirstPageButtonTest
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        public void Resolve(int currentPage, bool expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage };
            //act
            var value = SetShowFirstPageButton.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}