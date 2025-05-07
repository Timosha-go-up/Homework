namespace Task_10_5_interface
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = new Logger();

            var calculator = new SimpleCalkulator(Logger);
         
              while (true) {  calculator.Count();}                   
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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }


    }

    public interface IAddTwoNumbers
    {
        void Count();
        
    }

    public interface IValiidation
    {
        void Valid(string str);
    }
}
