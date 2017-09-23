using System;
using SimpleDddService.Infrastructure.Aspects.Logging.Handlers;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance;

namespace SimpleDddService.Infrastructure.Aspects.Logging.Implementation
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggerProxy _logProxy;

        public LoggingService(ILoggerProxy logProxy)
        {
            _logProxy = logProxy;
        }

        public void LogException(Exception ex)
        {
            Guard.ObjectNotNull(() => ex);
            _logProxy.LogError(ex, ex.Message);
        }

        public void LogInfo(string message)
        {
            Guard.StringNotNullorEmpty(() => message);
            _logProxy.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            Guard.StringNotNullorEmpty(() => message);
            _logProxy.LogWarning(message);
        }
    }
}