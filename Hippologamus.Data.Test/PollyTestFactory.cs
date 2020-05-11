using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippologamus.Data.Test
{
    public class PollyTestFactory
    {
        /// <summary>
        /// This creates a retry poicy that runs only ONCE, this is to be used in tests and they should ALWAYS work
        /// </summary>
        /// <returns></returns>
        public static AsyncRetryPolicy CreateAsyncRetryPolicy()
        {
            return Policy.Handle<Exception>().WaitAndRetryAsync(retryCount: 1, retryNumber => TimeSpan.FromMilliseconds(200));
        }
    }
}
