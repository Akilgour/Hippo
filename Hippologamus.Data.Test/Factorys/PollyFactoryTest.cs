using Hippologamus.Data.Factorys;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hippologamus.Data.Test.Factorys
{
    public class PollyFactoryTest
    {
        [Fact]
        public async Task CreateAsyncRetryPolicy_Exception()
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

        [Fact]
        public async Task CreateAsyncRetryPolicy_NoException()
        {
            //arrange
            var retyPolicy = PollyFactory.CreateAsyncRetryPolicy();
            int i = 0;

            //act
            await retyPolicy.ExecuteAsync(async () =>
             {
                 await Task.Delay(1); // This is here so there is something to await 
                 i++;
             });

            //assert
            Assert.Equal(1, i);
        }
    }
}