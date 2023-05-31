using NLog;
using ILogger = NLog.ILogger;

namespace BatchAPI.AppLog
{
    public class NLog : ILog
    {
        private static ILogger _logger =LogManager.GetCurrentClassLogger();
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Information(string message)
        {
            _logger.Info(message);
        }
        public void Warning(string message)
        {
            _logger.Warn(message);
        }
    }
}
