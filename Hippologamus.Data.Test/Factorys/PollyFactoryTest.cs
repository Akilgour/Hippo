using Hippologamus.Data.Factorys;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Factorys
{
    public class PollyFactoryTest
    {
        [Fact]
        public async Task CreateAsyncRetryPolicy()
        {
            //arrange
            var retyPolicy = PollyFactory.CreateAsyncRetryPolicy();
            int i = 0;

            //act
            Exception ex = await Assert.ThrowsAsync<Exception>(() => retyPolicy.ExecuteAsync(() =>
            {
                 i++;
                 throw new Exception($"Run number {i}");
            }));

            //assert
            Assert.Equal("Run number 6", ex.Message);
        }
    }
}