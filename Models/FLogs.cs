using Newtonsoft.Json;

namespace VtOdev.Models
{
    public class FLogs : ILoggerr
    {
        private readonly string _filePath = "C:/Users/Özgür Özkan/source/repos/VtOdev/wwwroot/Log.json";
        public void Log(string message)
        {
            var logEntry = new { Timestamp = DateTime.Now, Message = message };
            var json = JsonConvert.SerializeObject(logEntry);

            File.AppendAllText(_filePath, json + Environment.NewLine);
        }
    }
}
