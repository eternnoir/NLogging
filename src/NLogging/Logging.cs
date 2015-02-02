namespace NLogging
{
    using NLogging.Exceptions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Logging class. You can get logger by this class.
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

        private Dictionary<string, ILogger> loggerDictionary;

        private Logging()
        {
            this.loggerDictionary = new Dictionary<string, ILogger>();
        }

        /// <summary>
        /// Singleton get instance property. 
        /// </summary>
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

        /// <summary>
        /// Get loogger by logger name.
        /// </summary>
        /// <param name="loggerName">Which logger name you want to get.</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
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

        /// <summary>
        /// Add logger manually. But you can not add logger if thie logger name already exists. 
        /// </summary>
        /// <param name="logger">Your logger class.</param>
        /// <Exception crf="LoggerNameDuplicateException">If logger name already exists.</Exception>>
        public void AddLogger(ILogger logger)
        {
            lock (syncRoot)
            {
                if (this.loggerDictionary.ContainsKey(logger.Name))
                {
                    throw new LoggerNameDuplicateException("Logger Name " + logger.Name + " Duplicate.", logger.Name);
                }
                this.loggerDictionary.Add(logger.Name, logger);
            }
        }

    }
}