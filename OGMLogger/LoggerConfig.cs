namespace OGMUtility.Logger
{
    public class LoggerConfig
    {
        public enum LoggerType
        {
            UnityClient,
            NetServer,
        }
        public bool logActive = true;
        public readonly int logMaxLen = 100;
        public string logPrefix = "@";
        public bool showTime = true;
        public string logSep = "=>";
        public bool showTread = true;
        public bool isSave = true;
        public bool coverSave = true;
        public string savePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs\\";
        public string saveFileName = "GameLog.txt";
        public LoggerType loggerType = LoggerType.NetServer;
    }
}