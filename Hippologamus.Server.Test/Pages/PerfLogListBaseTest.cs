using Hippologamus.Server.Pages;
using Xunit;

namespace Hippologamus.Server.Test.Pages
{
    public class PerfLogListBaseTest
    {
        [Theory]
        [InlineData("AAA")]
        [InlineData("BBB")]
        [InlineData("CCC")]
        public void OrderBy_IsSet(string orderBy)
        {
            //arrange
            //act
            var value = new PerfLogListBase() { OrderBy = orderBy };
            //assert
            Assert.Equal(orderBy, value.OrderBy);
            Assert.True(value.OrderAscending);
        }

        [Theory]
        [InlineData("AAA", false)]
        [InlineData("BBB", true)]
        [InlineData("CCC", true)]
        public void OrderAscending_IsSet(string orderBy, bool expectedOrderAscending)
        {
            //arrange
            var value = new PerfLogListBase() { OrderBy = "AAA" };
            //act
            value.OrderBy = orderBy;
            //assert
            Assert.Equal(orderBy, value.OrderBy);
            Assert.Equal(expectedOrderAscending, value.OrderAscending);
        }
    }
}
