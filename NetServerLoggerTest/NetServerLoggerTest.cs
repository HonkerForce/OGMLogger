using OGMUtility.Logger;

public static class NetServerLoggerTest
{
    public static OGMLogger logger = new();
    public static void Main()
    {
        OGMLogger.InitLogConfig();
        OGMLogger.Log("Log Log", false, LogColor.Green);
        OGMLogger.Error("!!!Error!!!");
        OGMLogger.Warning("Warning!");

        string s = "";
        s.Log("s Log");
        s.LogTrace("s log log");
        s.Error("s !!!Error!!!");
        s.Warning("s Warning!");
        
        Console.ReadKey();
    }
}

public static class OGMLoggerExtensionMethods
{
    public static void Log(this object self, string msg, bool isShowStack = false, OGMUtility.Logger.LogColor color = OGMUtility.Logger.LogColor.None)
    {
        NetServerLoggerTest.logger.Log(msg, isShowStack, color);
    }
    public static void LogTrace(this object self, string msg, bool isShowStack = true)
    {
        NetServerLoggerTest.logger.LogTrace(msg, isShowStack);
    }

    public static void Warning(this object self, string msg)
    {
        NetServerLoggerTest.logger.Warning(msg);
    }

    public static void Error(this object self, string msg)
    {
        NetServerLoggerTest.logger.Error(msg);
    }
}