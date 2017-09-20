using System;
using Microsoft.Extensions.Logging;

namespace SimpleDddService.Infrastructure.Aspects.Logging.Implementation
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogException(Exception ex)
        {
            // Not sure what the EventId is used for
            _logger.LogError(new EventId(), ex, ex.Message);
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}