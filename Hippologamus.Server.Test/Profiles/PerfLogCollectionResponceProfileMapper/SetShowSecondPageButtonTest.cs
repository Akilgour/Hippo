using Hippologamus.Shared.DTO;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowSecondPageButtonTest
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        public void Resolve(int currentPage, bool expected)
        {
            //arrange
            var pagination = new Pagination() { CurrentPage = currentPage };
            //act
            var value = SetShowSecondPageButton.Resolve(pagination);
            //assert
            Assert.Equal(expected, value);
        }
    }
}