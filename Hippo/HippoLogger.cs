using Serilog;
using Serilog.Events;
using System;
using System.Data.SqlClient;

namespace Hippo
{
    public class HippoLogger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static HippoLogger()
        {
            _perfLogger = new LoggerConfiguration()
                .WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_PERF"))
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_USAGE"))
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_ERROR"))
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: Environment.GetEnvironmentVariable("LOGFILE_DIAG"))
                .CreateLogger();
        }

        public static void WritePerf(HippoLogDetail hippoLogDetail)
        {
            _perfLogger.Write(LogEventLevel.Information, "{@HippoLogDetail}", hippoLogDetail);
        }
        public static void WriteUsage(HippoLogDetail hippoLogDetail)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@HippoLogDetail}", hippoLogDetail);
        }
        public static void WriteError(HippoLogDetail hippoLogDetail)
        {
            if (hippoLogDetail.Exception != null)
            {
                var procName = FindProcName(hippoLogDetail.Exception);
                hippoLogDetail.Location = string.IsNullOrEmpty(procName)
                    ? hippoLogDetail.Location
                    : procName;
                hippoLogDetail.Message = GetMessageFromException(hippoLogDetail.Exception);
            }
            _errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", hippoLogDetail);
        }
        public static void WriteDiagnostic(HippoLogDetail infoToLog)
        {
            var writeDiagnostics = Convert.ToBoolean(Environment.GetEnvironmentVariable("DIAGNOSTICS_ON"));
            if (!writeDiagnostics)
            {
                return;
            }

            _diagnosticLogger.Write(LogEventLevel.Information, "{@HippoLogDetail}", infoToLog);
        }

        private static string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetMessageFromException(ex.InnerException);
            }

            return ex.Message;
        }

        private static string FindProcName(Exception ex)
        {
            var sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                var procName = sqlEx.Procedure;
                if (!string.IsNullOrEmpty(procName))
                {
                    return procName;
                }
            }

            if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
            {
                return (string)ex.Data["Procedure"];
            }

            if (ex.InnerException != null)
            {
                return FindProcName(ex.InnerException);
            }

            return null;
        }
    }
}