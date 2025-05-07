namespace Task_10_5_interface
{
   

    public class SimpleCalkulator : IAddTwoNumbers,IValiidation
    {
        static int one;
        static int two;
        int counter = 0;

        ILogger Logger { get; }

        public SimpleCalkulator(ILogger ilogger)
        {
            Logger = ilogger;
        }

        public void Count()
        {

            Logger.Event("Enter the number 1");

            Valid(Console.ReadLine());

            Logger.Event("Enter the number 2");

            Valid(Console.ReadLine());

            Console.WriteLine("Result of additon :" + (one + two)+"\n");

        }

        public void Valid(string str)
        {           
            try
            {                
              if(counter == 0)one =  Convert.ToInt32(str) ;
              else two = Convert.ToInt32(str);
              counter++;
            }
            catch (Exception)
            {
                Logger.Error("Something went wrong. Try again\n");
                
                Count();               
            }          
        }
      
    }

    

    
    
}
