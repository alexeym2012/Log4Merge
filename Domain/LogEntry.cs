using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Merge.Domain
{
    internal class LogEntry
    {
        public string SourceFileName { get; }
        public long LineNumber { get; }
        public DateTime TimeStamp { get; }
        public string Message { get; private set; }
        public string ShortMessage { get; set; }

        

        public string TimeStampAsText => TimeStamp.ToString(@"yyyy-MM-dd HH:mm:ss,fff");

        public LogEntry(
            string sourceFileName,
            long lineNumber,
            DateTime timeStamp,
            string message
            )
        {
            SourceFileName = sourceFileName;
            LineNumber = lineNumber;
            TimeStamp = timeStamp;
            Message = message;
            
            ShortMessage = Message;

            if (Message.Length > 100)
            {
                ShortMessage = Message.Substring(0, 100);
            }

        }

        public void AppendMessage(string message)
        {
            this.Message += $"\n{message}";
        }
    }
}
