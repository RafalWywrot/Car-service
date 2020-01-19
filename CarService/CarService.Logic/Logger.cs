using log4net;
using System;
using System.Reflection;

namespace CarService.Logic
{
    public static class Logger
    {
        private static ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Log(string message)
        {
            _log.Error(message);
        }

        public static void Log(Exception ex)
        {
            _log.Error(ex);
        }

        public static void Log(string message, Exception ex)
        {
            _log.Error(message, ex);
        }
    }
}