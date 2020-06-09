using Hippologamus.Server.Profiles.DetailLogCommentProfileMapper;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.DetailLogCommentProfileMapper
{
    public class OpenStateDisplayTest
    {
        [Theory]
        [InlineData(true, "Open")]
        [InlineData(false, "Closed")]
        public void Resolve(bool openState, string expected)
        {
            //arrange
            //act
            var value = OpenStateDisplay.Resolve(openState);
            //assert
            Assert.Equal(expected, value);
        }
    }
}