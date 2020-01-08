using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class ConsoleLogger : ILogger
    {

        public ConsoleLogger()
        {

        }
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("INFO: ");
            Console.Write(DateTime.Now.ToString("yyyy-mm-ddThh:mm:ss: "));
            Console.Write(message);
            Console.ResetColor();
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: ");
            Console.Write(DateTime.Now.ToString("yyyy-mm-ddThh:mm:ss: "));
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
