using System;
using Microsoft.Extensions.Logging;
using SimpleDddService.Infrastructure.Aspects.Logging.Implementation;

namespace SimpleDddService.Infrastructure.Aspects.Logging.Handlers.Implementation
{
    public class LoggerProxy : ILoggerProxy
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggerProxy(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}