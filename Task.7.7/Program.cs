namespace Task._7._7

   
{

    internal class Program
    {
        static void Main(string[] args)
        {

            HomeDelivery homeDelivery = new();
            HomeDelivery homeDelivery1 = new();

            PickPointDelivery pickPoint = new();
            PickPointDelivery pickPoint1 = new();

            ShopDelivery shopDelivery = new();
            ShopDelivery shopDelivery1 = new();

            Fruits fruits = new("apple", 5);
            Fruits fruits1 = new("Oranges", 8);

            Vegetables vegetables = new("Carrot", 7);
            Vegetables vegetables1 = new("Cabbage", 4);




            Order<Delivery, Groceries> order = new(homeDelivery, fruits);
            Order<Delivery, Groceries> order2 = new(homeDelivery1, vegetables);
            Order<Delivery, Groceries> order3 = new(pickPoint, fruits1);
            Order<Delivery, Groceries> order4 = new(pickPoint1, vegetables1);
            Order<Delivery, Groceries> order5 = new(shopDelivery, fruits);
            Order<Delivery, Groceries> order6 = new(shopDelivery1, vegetables);

            order.DisplayInfo();
            order2.DisplayInfo();
            order3.DisplayInfo();
            order4.DisplayInfo();
            order5.DisplayInfo();
            order6.DisplayInfo();

        }






        abstract class Delivery
        {
            internal string? Address;
            internal string? Courier;
            internal string? Desckription;
            protected static int Id = 0;
            private static string Default = "empty";
            internal int number;

            protected Delivery()
            {
                Id++;
                number = Id;
                Desckription = Address = Courier = Default;
            }

            public virtual void DateDelivery(bool adress = false) { }
        }


        /// <summary>
        /// домашняя доставка
        /// </summary>
        class HomeDelivery : Delivery
        {
            public override void DateDelivery(bool adress = false)
            {

                Address = "Зимняя 78";
                Desckription = "доставка по адресу покупателя";
                Courier = "Ivanov Иван";
            }
        }

        class PickPointDelivery : Delivery
        {
            public override void DateDelivery(bool adress = false)
            {
                Desckription = "доставка в пункт выдачи ";
                Address = "Лесная 6";
                Courier = "Федотов Григорий";
            }
        }

        class ShopDelivery : Delivery
        {
            public override void DateDelivery(bool adress = false)
            {
                Desckription = "доставка В магазин";
                Address = "5 Central street";
                Courier = "Сидоров Иннокентий ,Петров Петр";
            }

        }


        abstract class Groceries
        {
            public string? Name;
            public int Amount;

        }

        class Fruits : Groceries
        {
            public Fruits(string NameFruit, int Amount)
            {
                Name = NameFruit;
                this.Amount = Amount;
            }
        }


        class Vegetables : Groceries
        {
            public Vegetables(string NameVegetables, int Amount)
            {
                Name = NameVegetables;
                this.Amount = Amount;
            }

        }

        class Order<TDelivery, TGroceries> : Delivery where TDelivery : Delivery where TGroceries : Groceries
        {
            public TDelivery? Delivery;
            public TGroceries? Groceries;
            public int Number;
            public string? Description;


            public Order(TDelivery delivery, TGroceries groceries)
            {
                Number = Delivery?.number ?? -1;
                Description = Delivery?.Desckription ?? "empty";
                Delivery = delivery;
                Groceries = groceries;
            }

            public void DisplayInfo()
            {
                Delivery?.DateDelivery();

                Console.WriteLine($"Заказ номер\t: {Delivery?.number ?? -1}");
                Console.Write($"Тип доставки\t: {Delivery?.Desckription ?? "empty"}\n");
                Console.WriteLine($"Состав доставки\t: {Groceries?.Name} ,количество: {Groceries?.Amount}");
                Console.Write($"адрес доставки\t: {Delivery?.Address ?? "empty"}\n");
                Console.Write($"Доставляет\t: {Delivery?.Courier ?? "empty"}\n\n");
            }
        }


    }
}
