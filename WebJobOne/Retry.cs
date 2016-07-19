using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;

namespace WebJobOne
{
    public static class Retry
    {
        public static void Run()
        {
            // Set up the retry strategy
            string defaultRetryStrategyName = "myStrategy";
            int retryCount = 10;
            var retryInterval = TimeSpan.FromSeconds(10);
            var strategy = new FixedInterval(defaultRetryStrategyName, retryCount, retryInterval);
            var strategies = new List<RetryStrategy> { strategy };

            // Create the retry manager
            var manager = new RetryManager(strategies, defaultRetryStrategyName);

            // Register the retry manager
            RetryManager.SetDefault(manager);            

            var policy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromSeconds(5));

            using (var conn = new ReliableSqlConnection("connectionString...", policy))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 Name FROM Users";
                var result = cmd.ExecuteScalar();
            }
        }
    }
}
