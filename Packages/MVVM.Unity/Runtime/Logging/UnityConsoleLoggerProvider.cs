using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MVVM.Unity.Logging
{
    public class UnityConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, UnityConsoleLogger> _loggers = new();

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(
                categoryName,
                name => new UnityConsoleLogger(name));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}