using System;

namespace Logging
{
    public interface ILogger
    {
        void EnterMethod(string methodName);

        void LeaveMethod(string methodName);

        void LogException(Exception exception);

        void LogError(string message);

        void LogWarningMessage(string message);

        void LogInfoMessage(string message);

        void LogDebugMessage(string message);
    }
}