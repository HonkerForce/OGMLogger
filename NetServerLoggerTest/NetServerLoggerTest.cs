using OGMUtility.Logger;

public static class NetServerLoggerTest
{
    public static void Main()
    {
        OGMLogger.InitLogConfig();
        OGMLogger.Log("Log Log", LogColor.Green);
        Console.ReadKey();
    }
}