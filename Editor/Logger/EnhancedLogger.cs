using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Editor.Logger
{
    public class EnhancedLogger : ILogHandler
    {
        private readonly ILogHandler _defaultLogHandler = Debug.unityLogger.logHandler;

        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            var message = LoggerExtensions.GetLogFormat(logType, context, args);
            _defaultLogHandler.LogFormat(logType, context, format, message);
        }

        public void LogException(Exception exception, Object context)
        {
            _defaultLogHandler.LogException(exception, context);
        }
    }
}