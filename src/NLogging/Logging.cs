namespace NLogging
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Logging class.
    /// </summary>
    public class Logging
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static volatile Logging instance;
        /// <summary>
        /// For thread safe.
        /// </summary>
        private static object syncRoot = new object();

        private Dictionary<string, Logger> loggerDictionary;

        private Logging()
        {
            this.loggerDictionary = new Dictionary<string, Logger>();
        }

        public static Logging Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Logging();
                    }
                }
                return instance;
            }
        }

        public Logger GetLogger(string loggerName)
        {
            lock (syncRoot)
            {
                if (!this.loggerDictionary.ContainsKey(loggerName))
                {
                    this.loggerDictionary.Add(loggerName, new Logger(loggerName));
                }
                return this.loggerDictionary[loggerName];
            }
        }

    }
}