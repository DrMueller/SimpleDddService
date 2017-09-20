using System;

namespace SimpleDddService.Infrastructure.Aspects.Logging
{
    public interface ILoggingService
    {
        void LogException(Exception ex);

        void LogInfo(string message);

        void LogWarning(string message);
    }
}