﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nito.Logging;

namespace ExceptionLoggingScopeUnitTests.Utility
{
    public class LoggingTestUtility
    {
        public static void InitializeLogs(Action<InMemoryLoggerProvider, ILogger> action)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            var logs = new InMemoryLoggerProvider();
            services.AddSingleton<ILoggerProvider>(logs);
            services.AddExceptionLoggingScopes();
            using var provider = services.BuildServiceProvider();

            var logger = provider.GetRequiredService<ILogger<BasicUsageUnitTests>>();
            action(logs, logger);
        }

        public static (InMemoryLoggerProvider Logs, ILogger Logger) InitializeLogs()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            var logs = new InMemoryLoggerProvider();
            services.AddSingleton<ILoggerProvider>(logs);
            services.AddExceptionLoggingScopes();
            var provider = services.BuildServiceProvider();

            var logger = provider.GetRequiredService<ILogger<BasicUsageUnitTests>>();
            return (logs, logger);
        }
    }
}