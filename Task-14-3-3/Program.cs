internal class Program
{
    private static void Main(string[] args)
    {
        // создаём пустой список с типом данных Contact
        var phoneBook = new List<Contact>
            {
                // добавляем контакты
                new("Сергей",     "Довлатов", 79990000010, "serge@example.com"),
                new("Игорь",      "Николаев", 79990000001, "igor@example.com"),
                new("Игорь",      "Крутой", 799900004, "igorК@example.com"),
                new("Валерий",    "Леонтьев", 79990000012, "valera@example.com"),
                new("Анатолий",   "Карпов", 79990000011, "anatoly@example.com"),
                new("Анатолий",   "Папанов", 799900005, "anatolyП@example.com"), 
                new("Сергей",     "Есенин", 79990006, "sergE@example.com"),
                new("Сергей",     "Брин", 799900000013, "serg@example.com"),
                new("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"),
               
            };


        while (true)
        {
            var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
            Console.Clear();  //  очистка консоли от ввода
                                         
            if (!Char.IsDigit(keyChar))
            {
                Console.WriteLine("Ошибка ввода, введите число");
            }
            else
            {
                //  переменная для хранения запроса в зависимости от введенного с консоли числа
                IEnumerable<Contact> page = null;

                //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
                switch (keyChar)
                {
                    case ('1'):
                        page = phoneBook.Take(3);
                        break;
                    case ('2'):
                        page = phoneBook.Skip(3).Take(3);
                        break;
                    case ('3'):
                        page = phoneBook.Skip(6).Take(3);
                        break;
                }

                //   проверим, что ввели существующий номер страницы

                if (page == null)
                {
                    Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                }

                // вывод результата на консоль

                Console.WriteLine("Before sort");
                foreach (var contact in page)
                    Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);
                Console.WriteLine();

                Console.WriteLine("After sort");
                var sortContact = from s in page orderby s.Name, s.LastName select s;
                foreach (var contact in sortContact)
                    Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);
            }
        }
    }
}