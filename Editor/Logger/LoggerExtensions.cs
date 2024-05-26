using System;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Editor.Logger
{
    public static class LoggerExtensions
    {
        private const string LogColor = "gray";
        private const string WarningColor = "yellow";
        private const string ErrorColor = "red";
        private const string AssertColor = "green";
        private const string ExceptionColor = "orange";
        private const string ObjectColor = "lightblue";

        private const string ColorStart = "<color=";
        private const string ColorEnd = "</color>";
        private const string ColorMiddle = ">";
        private const string Colon = ":";
        private const string Divider = ";\n";
        private const string Space = " ";

        private static readonly StringBuilder Builder = new();

        private static string GetColor(this string str, string color)
        {
            var message = Builder.Append(ColorStart).Append(color).Append(ColorMiddle).Append(str).Append(ColorEnd)
                .ToString();
            Builder.Clear();
            return message;
        }

        private static string GetLogTypeColor(this LogType logType)
        {
            return logType switch
            {
                LogType.Log => logType.ToString().GetColor(LogColor),
                LogType.Warning => logType.ToString().GetColor(WarningColor),
                LogType.Error => logType.ToString().GetColor(ErrorColor),
                LogType.Assert => logType.ToString().GetColor(AssertColor),
                LogType.Exception => logType.ToString().GetColor(ExceptionColor),
                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, null)
            };
        }

        public static string GetLogFormat(LogType prefix, Object obj, params object[] message)
        {
            string formatMessage = null;
#if UNITY_EDITOR

            var format = Builder.Append(prefix.GetLogTypeColor()).Append(Space);
            if (obj is not null)
                format.Append(obj.name.GetColor(ObjectColor));

            format.Append(Colon).Append(Space).Append(string.Join(Divider, message));
            formatMessage = format.ToString();
#endif
            Builder.Clear();

            return formatMessage;
        }
    }
}