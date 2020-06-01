using Hippologamus.Server.Profiles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Server.Test.Profiles.Shared
{
    public class ElapsedMillisecondsDisplayTest
    {
        [Theory]
        [InlineData(1, "0 sec 1 ms")]
        [InlineData(10, "0 sec 10 ms")]
        [InlineData(1000, "1 sec 0 ms")]
        [InlineData(1817, "1 sec 817 ms")]
        [InlineData(1963, "1 sec 963 ms")]
        [InlineData(2000, "2 sec 0 ms")]
        [InlineData(2141, "2 sec 141 ms")]
        [InlineData(2412, "2 sec 412 ms")]
        [InlineData(3000, "3 sec 0 ms")]
        [InlineData(3094, "3 sec 94 ms")]
        [InlineData(60000, "1 min 0 sec 0 ms")]
        [InlineData(61000, "1 min 1 sec 0 ms")]
        [InlineData(60100, "1 min 0 sec 100 ms")]
        [InlineData(60001, "1 min 0 sec 1 ms")]
        [InlineData(120000, "2 min 0 sec 0 ms")]
        [InlineData(7200000, "2 hour 0 min 0 sec 0 ms")]
        [InlineData(172800000, "2 day 0 hour 0 min 0 sec 0 ms")]
        [InlineData(172810001, "2 day 0 hour 0 min 10 sec 1 ms")]
        public void Resolve(int milliseconds, string expected)
        {
            //arrange
            //act
            var value = ElapsedMillisecondsDisplay.Resolve(milliseconds);
            //assert
            Assert.Equal(expected, value);
        }
    }
}
