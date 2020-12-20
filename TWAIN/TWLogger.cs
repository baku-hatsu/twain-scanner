using NTwain;
using System;
using System.Diagnostics;

namespace TWAIN
{
    public class TWLogger : ILog
    {
        private readonly EventLog _eventLog;

        public TWLogger()
        {
            IsInfoEnabled = true;
            IsDebugEnabled = true;
            IsErrorEnabled = true;

            _eventLog = new EventLog("Application")
            {
                Source = "TWAIN Scanner"
            };
        }

        public bool IsInfoEnabled { get; set; }
        public bool IsDebugEnabled { get; set; }
        public bool IsErrorEnabled { get; set; }

        public void Debug(string message)
        {
            _eventLog.WriteEntry(message, EventLogEntryType.Warning);
        }

        public void Debug(string messageFormat, params object[] args)
        {
            _eventLog.WriteEntry(string.Format(messageFormat, args), EventLogEntryType.Warning);
        }

        public void Error(string message)
        {
            _eventLog.WriteEntry(message, EventLogEntryType.Error);
        }

        public void Error(string message, Exception exception)
        {
            _eventLog.WriteEntry($"{message}. Exception message: {exception.Message}. — Inner exception message {exception.InnerException.Message}", EventLogEntryType.Error);
        }

        public void Error(string messageFormat, Exception exception, params object[] args)
        {
            _eventLog.WriteEntry($"Message format: {string.Format(messageFormat, args)}. Exception message: {exception.Message}. — Inner exception message {exception.InnerException.Message}", EventLogEntryType.Error);
        }

        public void Info(string message)
        {
            _eventLog.WriteEntry(message, EventLogEntryType.Information);
        }

        public void Info(string messageFormat, params object[] args)
        {
            _eventLog.WriteEntry(string.Format(messageFormat, args), EventLogEntryType.Information);
        }
    }
}
