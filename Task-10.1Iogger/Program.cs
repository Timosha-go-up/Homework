using System.Globalization;
using System.Runtime.CompilerServices;

namespace Task_10._1Iogger
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();

            var worker1 = new Worker1(Logger);
            var worker2 = new Worker2(Logger);
            var worker3 = new Worker3(Logger);

            worker1.Work();
            worker2.Work();
            worker3.Work();
        }       
    }

    public interface ILogger
    {
      public void Event(string message);

     public void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

       
    }

    public interface IWorker 
    {
        void Work();
    }
}
