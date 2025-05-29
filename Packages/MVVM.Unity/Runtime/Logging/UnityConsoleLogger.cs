using Microsoft.Extensions.Logging;
using System;
using UnityEngine;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MVVM.Unity.Logging
{
    public class UnityConsoleLogger : ILogger
    {
        private readonly string _name;

        public UnityConsoleLogger(string name)
        {
            _name = name;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Debug.LogAssertion($"{_name} - {formatter(state, exception)}");
                    break;
                case LogLevel.Error:
                    Debug.LogError($"{_name} - {formatter(state, exception)}");
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning($"{_name} - {formatter(state, exception)}");
                    break;
                case LogLevel.Information:
                case LogLevel.Trace:
                case LogLevel.Debug:
                    Debug.Log($"{_name} - {formatter(state, exception)}");
                    break;
                case LogLevel.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }
    }
}