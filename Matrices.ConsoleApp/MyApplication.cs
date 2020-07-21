using System;

namespace Matrices.ConsoleApp
{
    internal class MyApplication
    {
        private readonly ILogger _logger;

        public MyApplication(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Yraaa!!!!");
        }
    }



    internal interface ILogger
    {
        void Log(string message);
    }



    internal class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}