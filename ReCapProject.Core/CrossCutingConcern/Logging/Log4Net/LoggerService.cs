using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Repository;

namespace ReCapProject.Core.CrossCutingConcern.Logging.Log4Net
{[Serializable]
    public class LoggerService
    {
        private ILog _log;

        public LoggerService(ILog name)
        {
            XmlDocument xmlDocument=new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name);
        }

        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsErrorEnabled => _log.IsFatalEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsInfoEnabled => _log.IsInfoEnabled;

        public void Info(object message)
        {
            if (IsInfoEnabled)
            { 
                _log.Info(message);
            }
        }

        public void Error(object message)
        {
            if (IsErrorEnabled)
            {
                _log.Error(message);
            }
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(message);
            }
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(message);
            }
        }


    }
}
