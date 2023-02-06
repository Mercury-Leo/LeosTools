using System;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor.Logger {
    public static class LoggerExtensions {
        const string LogColor = "gray";
        const string WarningColor = "yellow";
        const string ErrorColor = "red";
        const string AssertColor = "green";
        const string ExceptionColor = "orange";
        const string ObjectColor = "lightblue";

        const string ColorStart = "<color=";
        const string ColorEnd = "</color>";
        const string ColorMiddle = ">";
        const string Colon = ":";
        const string Divider = ";\n";
        const string Space = " ";

        static readonly StringBuilder Builder = new();

        static string GetColor(this string str, string color) {
            var message = Builder.Append(ColorStart).Append(color).Append(ColorMiddle).Append(str).Append(ColorEnd)
                .ToString();
            Builder.Clear();
            return message;
        }

        static string GetLogTypeColor(this LogType logType) {
            return logType switch {
                LogType.Log => logType.ToString().GetColor(LogColor),
                LogType.Warning => logType.ToString().GetColor(WarningColor),
                LogType.Error => logType.ToString().GetColor(ErrorColor),
                LogType.Assert => logType.ToString().GetColor(AssertColor),
                LogType.Exception => logType.ToString().GetColor(ExceptionColor),
                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, null)
            };
        }

        public static string GetLogFormat(LogType prefix, Object obj, params object[] message) {
            string formatMessage;
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