using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhika.GetMyPublicIp.Utility
{
    public class WriteEventLog
    {
        static string sSource = "GetMyPublicIp";
        static string sLog = "Application";
        
        public static void Write(string message, EventLogEntryType type)
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, message, type);
        }
    }
}
