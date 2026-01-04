using OGMUtility.Logger;

public static class NetServerLoggerTest
{
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