using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Tracing;
using NLog;
using System.Net.Http;

namespace MupadoodleAPI.Models
{
    public class NLogger : ITraceWriter
    {
        private static Lazy<Dictionary<TraceLevel, Action<string>>> loggingMap = new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>> { 
            {TraceLevel.Info, LogManager.GetCurrentClassLogger().Info},
            {TraceLevel.Debug, LogManager.GetCurrentClassLogger().Debug},
            {TraceLevel.Error, LogManager.GetCurrentClassLogger().Error},
            {TraceLevel.Fatal, LogManager.GetCurrentClassLogger().Fatal},
            {TraceLevel.Warn, LogManager.GetCurrentClassLogger().Warn}
     });

        private Dictionary<TraceLevel, Action<string>> _logger
        {
            get
            {
                return loggingMap.Value;
            }
        }
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                TraceRecord record = new TraceRecord(request, category, level);
                traceAction(record);
                Log(record);
            }
        }

        public bool IsEnabled(string category, TraceLevel level)
        {
            return true; //obsolete
        }

        private void Log(TraceRecord record)
        {
            var message = string.Empty;

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message += " " + record.Request.Method.ToString();

                if (record.Request.RequestUri != null)
                    message += " " + record.Request.RequestUri.ToString();
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message += " " + record.Category;

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message += " " + record.Operator + " " + record.Operation;

            if (!string.IsNullOrWhiteSpace(record.Message))
                message += " " + record.Message;

            if (record.Exception != null)
            {
                if (record.Exception.GetBaseException().Message != null)
                    message += record.Exception.GetBaseException().Message;
            }

            _logger[record.Level](message);
        }
    }
}