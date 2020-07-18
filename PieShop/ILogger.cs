using System;
using System.IO;

namespace PieShop
{
    public interface ILog
    {
        void LogException(string message);
    }

    public sealed class Log : ILog
    {
        public void LogException(string message)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "Log.txt";
            string currDir = AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName;

            using (var s = new StreamWriter(currDir))
            {
                s.WriteLine(message);
                s.Flush();
            }

            Console.WriteLine(message);
        }
    }
}
