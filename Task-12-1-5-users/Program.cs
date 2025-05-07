namespace Task_12_1_5_users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users =
            [
                new("Fox","Ivan",true),
                new("Rat", "Maksim"),
                new("Bird", "Sergey"),
                new("Bear","Nicolay",true),
            ];

            foreach (var user in users) user.Print();

            Console.ReadKey();
        }


        class User
        {
            string? Login { get; set; }
            string? Name { get; set; }
            bool IsPremium { get; set; }

            public User(string login, string name, bool status = false)
            {
                Login = login;
                Name = name;
                IsPremium = status;
            }

            public void Print()
            {
                if (IsPremium) Console.WriteLine($"Welkome back!\t {Name} Your login {Login}");

                else
                {
                    Console.WriteLine($"Welkome to our website!\t {Name} Your login {Login}"); ShowAds();
                }
                Console.WriteLine();
            }
        }


        static void ShowAds()
        {
            Console.WriteLine("Оформите премиум-подписку со скидкой 75% при оплате за 1 год.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }





    }
}
