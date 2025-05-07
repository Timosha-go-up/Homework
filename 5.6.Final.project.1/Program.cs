using System;

namespace _5._6.Final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Необходимо создать метод, который заполняет данные с клавиатуры по пользователю(возвращает кортеж):
            //    Имя;
            //Фамилия;
            //Возраст;
            //Наличие питомца;                                  
            //Если питомец есть, то запросить количество питомцев;
            //Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек(заполнение с клавиатуры);
            //Запросить количество любимых цветов;
            //Вызвать метод, который возвращает массив любимых цветов по их количеству(заполнение с клавиатуры);
            //Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
            //Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
            //Корректный ввод: ввод числа типа int больше 0.
            //Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
            //Вызов методов из метода Main.

            (string Name, string SurName, int Age, bool HavePet, int NumberPets, string[] NamesPets, int NumberFavcolors, string[] NamesColors) Anketa;
            Anketa = ("Name", "surname", 0, false, 0, null, 0, null);


            UserAnketa(ref Anketa);

            Console.WriteLine();

            PrintAnketa(ref Anketa);

            Console.ReadKey();

        }

        static void UserAnketa(ref (string Name, string SurName, int Age, bool HavePet, int NumberPets, string[] NamesPets, int NumberFavcolors, string[] NamesColors) anketa)
        {

            Console.Write("Enter your name:\t");
            anketa.Name = Console.ReadLine();

            Console.Write("Enter your surname:\t");
            anketa.SurName = Console.ReadLine();

            Console.Write("Enter your age:\t\t");
            anketa.Age = CorrectData();

            Console.Write("Write 'yes' if you have pets: ");
            if ("yes" == Console.ReadLine())
            {
                anketa.HavePet = true;

                Console.Write("Enter the number of pets: ");

                anketa.NumberPets = CorrectData();

                anketa.NamesPets = ListOfNames(ref anketa.NumberPets, "A pet\t: ");
            }
            else anketa.HavePet = false;


            Console.Write("Enter the numbers of your favorit colors:");
            anketa.NumberFavcolors = CorrectData();
            anketa.NamesColors = ListOfNames(ref anketa.NumberFavcolors, "Color\t: ");

        }

        static int CorrectData()
        {
            try
            {
                int data = int.Parse(Console.ReadLine());

                if (data > 0) return data;

                else
                {
                    Console.Write("Incorrect input please try again\n");
                    return CorrectData();
                }
            }
            catch (Exception)
            {
                Console.Write("Incorrect input please try again\n");
                return CorrectData();
            }
        }

        static string[] ListOfNames(ref int size, string type)
        {
            if (size > 5) size = 5;

            string[] names = new string[size];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write(type + " " + (i + 1) + "\t");
                names[i] = Console.ReadLine();
            }
            return names;
        }


        static void PrintAnketa(ref (string Name, string SurName, int Age, bool HavePet, int NumberPets, string[] NamesPets, int NumberFavcolors, string[] NamesColors) anketa)
        {
            Console.WriteLine("Your name \t" + anketa.Name);
            Console.WriteLine("Your surname \t" + anketa.SurName);
            Console.WriteLine("Your age \t" + anketa.Age + "  year old");
            Console.WriteLine("Have pets \t" + anketa.HavePet);
            if (anketa.HavePet)
            {
                Console.Write("Number of yours pets \t" + anketa.NumberPets + "\t");
                for (int i = 0; i < anketa.NumberPets; i++) Console.Write(anketa.NamesPets[i] + " . ");
            }
            Console.Write("\n" + "Yours favorit colors \t" + anketa.NumberFavcolors + "\t");
            for (int i = 0; i < anketa.NumberFavcolors; i++) Console.Write(anketa.NamesColors[i] + " . ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
