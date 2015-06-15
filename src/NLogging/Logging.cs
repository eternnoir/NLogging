namespace NLogging
{
    using NLogging.Exceptions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Logging class. You can get logger by this class.
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static bool DebugMode { get; set; }

        /// <summary>
        /// For thread safe.
        /// </summary>
        private static object syncRoot = new object();

        private static Dictionary<string, ILogger> loggerDictionary = new Dictionary<string, ILogger>();

        /// <summary>
        /// Get loogger by logger name.
        /// </summary>
        /// <param name="loggerName">Which logger name you want to get.</param>
        /// <returns></returns>
        public static ILogger GetLogger(string loggerName)
        {
            lock (syncRoot)
            {
                if (!loggerDictionary.ContainsKey(loggerName))
                {
                    loggerDictionary.Add(loggerName, new Logger(loggerName));
                }
                return loggerDictionary[loggerName];
            }
        }

        /// <summary>
        /// Add logger manually. But you can not add logger if thie logger name already exists. 
        /// </summary>
        /// <param name="logger">Your logger class.</param>
        /// <Exception crf="LoggerNameDuplicateException">If logger name already exists.</Exception>
        public static void AddLogger(ILogger logger)
        {
            lock (syncRoot)
            {
                if (loggerDictionary.ContainsKey(logger.Name))
                {
                   WriteDebugMessage("Logger Name " + logger.Name + " Duplicate.");
                   return;
                }
                loggerDictionary.Add(logger.Name, logger);
            }
        }


        public static void WriteDebugMessage(string message)
        {
            if (DebugMode)
            {
                System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(message));
                System.Diagnostics.Trace.WriteLine(FormateDebugMessage(message));
            }
        }

        private static String FormateDebugMessage(string message)
        {
            String formatedMessage = String.Format("[NLogging] {0} -- {1}", DateTime.Now.ToString(), message);
            return formatedMessage;
        }

    }
}