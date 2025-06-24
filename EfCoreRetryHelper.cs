using System;
using System.Threading.Tasks;
using Npgsql;
using Polly;
using Polly.Retry;

namespace DeveloperStore.Infrastructure.Helpers
{
    public static class EfCoreRetryHelper
    {
        private static readonly AsyncRetryPolicy RetryPolicy = Policy
            .Handle<NpgsqlException>()
            .WaitAndRetryAsync(
                retryCount: 5,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Tentativa {retryCount} falhou: {exception.Message}. Retentando em {timeSpan.TotalSeconds}s.");
                });

        public static async Task ExecuteWithRetryAsync(Func<Task> operation)
        {
            await RetryPolicy.ExecuteAsync(operation);
        }

        public static async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> operation)
        {
            return await RetryPolicy.ExecuteAsync(operation);
        }
    }
}
