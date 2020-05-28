using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowPerviousPageButtonTest
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        public void Create_Contains(int paginationCurrentPage, bool expected)
        {
            //arrange
            //act
            var value = SetShowPerviousPageButton.Resolve(paginationCurrentPage);
            //assert
            Assert.Equal(expected, value);
        }
    }
}
