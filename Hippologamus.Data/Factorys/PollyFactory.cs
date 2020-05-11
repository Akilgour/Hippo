using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using System;

namespace Hippologamus.Data.Factorys
{
    public static class PollyFactory
    {
        public static AsyncRetryPolicy CreateAsyncRetryPolicy()
        {

            //Taken from https://github.com/Polly-Contrib/Polly.Contrib.WaitAndRetry#wait-and-retry-with-jittered-back-off

            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);

            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(delay);
            return retryPolicy;
        }
    }
}
