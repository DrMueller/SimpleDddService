﻿using System;

namespace SimpleDddService.Infrastructure.Application.Aspects.Logging.Handlers
{
    public interface ILoggerProxy
    {
        void LogError(Exception ex, string message);

        void LogInformation(string message);

        void LogWarning(string message);
    }
}