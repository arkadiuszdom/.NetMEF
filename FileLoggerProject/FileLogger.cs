using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces;

namespace FileLoggerProject
{

    [Export(typeof(ILogger))]
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            builder.Append(" - ");
            builder.Append(message);
            StreamWriter sw = File.AppendText("TestLog.txt");
            sw.WriteLine(builder.ToString());
            sw.Close();
        }
    }
}
