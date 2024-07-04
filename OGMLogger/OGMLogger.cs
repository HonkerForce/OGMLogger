using System.Reflection;

namespace OGMUtility.Logger
{        
    public enum LogColor
    {
        Grey,
        Red,
        Green,
        Blue,
        Cyan,
        Magenta,
        Yellow,
        Black,
    }
    
    public interface ILogger
    {
        void Log(string msg, LogColor color);
        void Warning(string msg);
        void Error(string msg);
    }
    
    public static class OGMLogger
    {
        public class NetServerLogger : ILogger
        {
            public void Log(string msg, LogColor color)
            {
                printLog(msg, color);
            }

            public void Warning(string msg)
            {
                printLog(msg, LogColor.Yellow);
            }

            public void Error(string msg)
            {
                printLog(msg, LogColor.Red);
            }

            private void printLog(string msg, LogColor color)
            {
                switch (color)
                {
                    case LogColor.Grey:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case LogColor.Red:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case LogColor.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case LogColor.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case LogColor.Cyan:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case LogColor.Magenta:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case LogColor.Yellow:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case LogColor.Black:
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        
        public class UnityClientLogger : ILogger
        {
            private Type debugType = Type.GetType("UnityEngine.Debug");
            private MethodInfo debugMethod;
            public UnityClientLogger()
            {
                debugType ??= Type.GetType("UnityEngine.Debug");
                if (debugType != null)
                {
                    debugMethod ??= debugType.GetMethod("Log", new[] { typeof(object) });
                }
            }
            public void Log(string msg, LogColor color)
            {
                debugMethod?.Invoke(null, new[] { genericMsg(msg, color) });
            }

            public void Warning(string msg)
            {
                debugMethod?.Invoke(null, new[] { genericMsg(msg, LogColor.Yellow) });
            }

            public void Error(string msg)
            {
                debugMethod?.Invoke(null, new[] { genericMsg(msg, LogColor.Red) });
            }

            private string genericMsg(string msg, LogColor color)
            {
                string ret = "";
                switch (color)
                {
                    case LogColor.Grey:
                        break;
                    case LogColor.Red:
                        ret = $"<color=#FF0000>{msg}</color>";
                        break;
                    case LogColor.Green:
                        ret = $"<color=#00FF00>{msg}</color>";
                        break;
                    case LogColor.Blue:
                        ret = $"<color=#0000FF>{msg}</color>";
                        break;
                    case LogColor.Cyan:
                        ret = $"<color=#00FFFF>{msg}</color>";
                        break;
                    case LogColor.Magenta:
                        ret = $"<color=#FF00FF>{msg}</color>";
                        break;
                    case LogColor.Yellow:
                        ret = $"<color=#FFFF00>{msg}</color>";
                        break;
                    case LogColor.Black:
                        ret = $"<color=#FFFFFF>{msg}</color>";
                        break;
                    default:
                        break;
                }

                return ret;
            }
        }

        private static ILogger logger;
        public static LoggerConfig logConfig;
        public static void InitLogConfig(LoggerConfig cfg = null)
        {
            if (cfg == null)
            {
                logConfig = new LoggerConfig();
            }
            else
            {
                logConfig = cfg;
            }

            if (logConfig.loggerType == LoggerConfig.LoggerType.NetServer)
            {
                logger = new NetServerLogger();
            }
            else if (logConfig.loggerType == LoggerConfig.LoggerType.UnityClient)
            {
                logger = new UnityClientLogger();
            }
        }

        public static void Log(string msg, LogColor color)
        {
            if (!logConfig.logActive)
            {
                return;
            }
            logger?.Log(msg, color);
        }

        public static void Warning(string msg)
        {
            if (!logConfig.logActive)
            {
                return;
            }
            logger?.Warning(msg);
        }

        public static void Error(string msg)
        {
            if (!logConfig.logActive)
            {
                return;
            }
            logger?.Error(msg);
        }
    }
}