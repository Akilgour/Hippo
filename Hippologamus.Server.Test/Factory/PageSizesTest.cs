using Hippologamus.Server.Factorys;
using System.Linq;
using Xunit;

namespace Hippologamus.Server.Test.Factory
{
    public class PageSizesTest
    {
        [Fact]
        public void Create_Count()
        {
            //arrange
            //act
            var value = PageSizes.Create();
            //assert
            Assert.Equal(4, value.Count);
        }

        [Theory]
        [InlineData(10, "Show 10")]
        [InlineData(50, "Show 50")]
        [InlineData(100, "Show 100")]
        [InlineData(-1, "Show All")]
        public void Create_Contains(int? showPageSizeValue, string showPageSizeDescription)
        {
            //arrange
            //act
            var value = PageSizes.Create();
            //assert
            var item = value.First(x => x.ShowPageSizeValue == showPageSizeValue);
            Assert.Equal(showPageSizeValue, item.ShowPageSizeValue);
            Assert.Equal(showPageSizeDescription, item.ShowPageSizeDescription);
        }
    }
}
