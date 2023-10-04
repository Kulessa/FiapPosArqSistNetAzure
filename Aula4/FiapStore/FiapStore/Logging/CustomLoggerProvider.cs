using System.Collections.Concurrent;

namespace FiapStore.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration loggerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> loggers = new();
        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerConfig = loggerConfig;
        }
        public ILogger CreateLogger(string categoria)
        {
            return loggers.GetOrAdd(
                categoria,
                nome => new CustomLogger(nome, loggerConfig));
        }
        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
