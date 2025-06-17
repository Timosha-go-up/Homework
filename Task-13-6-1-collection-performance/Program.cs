using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Linq;

internal class Program
{   
    private static void Main(string[] args)
    {
        var path = "C:\\Users\\Roman-PC\\Downloads\\input.txt";

        var fileInfo = new FileInfo(path);

        using StreamReader sr = fileInfo.OpenText();

        var str = sr.ReadToEnd();
                        
        string[] ArrayString = str.Split([' ', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
       
        List<string>? list = [];
        LinkedList<string>? linced_list = new();
       
        //замеры встаки в list

        TestList(list, ArrayString,incertAtBeginning:true);
        TestList(list, ArrayString,insertInMiddle:true);
        TestList(list, ArrayString,add:true);

        Console.WriteLine();

        //замеры вставки в lincedlist
       
        TestLincedList(linced_list,ArrayString,addfirst:true);
        TestLincedList(linced_list, ArrayString, insertInMiddle:true);
        TestLincedList(linced_list, ArrayString, addlast:true);

        Console.ReadKey();
    }

    static void TestList(List<string> list, string[] ArrayString,bool incertAtBeginning = false,bool insertInMiddle = false,bool add = false) 
    {
        if (add)
        {
            var watch = Stopwatch.StartNew();
            foreach (var item in ArrayString) list.Add(item);
            Console.WriteLine($"Вставка в  конец коллекции list : {watch.Elapsed.TotalMilliseconds}  мс");
            list.Clear();
        }

        else if (insertInMiddle)
        {
            var watch = Stopwatch.StartNew();
            foreach (var item in ArrayString) list.Insert(list.Count / 2, item);
            Console.WriteLine($"Вставка в середину коллекции list : {watch.Elapsed.TotalMilliseconds}  мс");
            list.Clear();
        }

        else if (incertAtBeginning)
        {
            var watch = Stopwatch.StartNew();
            foreach (var item in ArrayString) list.Insert(0, item);
            Console.WriteLine($"Вставка в начало коллекции list : {watch.Elapsed.TotalMilliseconds}  мс");
            list.Clear();
        }
    }

    static void TestLincedList(LinkedList<string>? linced_list, string[] ArrayString, bool addfirst = false, bool insertInMiddle = false, bool addlast = false)
    {
        if (addfirst)
        {
            var watch = Stopwatch.StartNew();
            foreach (var item in ArrayString) linced_list.AddFirst(item);
            Console.WriteLine($"Вставка в начало коллекции lincedlist : {watch.Elapsed.TotalMilliseconds}  мс");
            linced_list.Clear();
        }
        else if (insertInMiddle) 
        {
            LinkedListNode<string> node = linced_list.First;

            var watch = Stopwatch.StartNew();
            var current = linced_list.First;
            foreach (var item in ArrayString)
            {
                if (linced_list.Count < 2)
                {
                    linced_list.AddLast(item);
                }

                else
                {
                    node = linced_list.First;

                    //search for the center element
                    for (int i = 0; i < linced_list.Count / 2; i++)
                    {
                        node = node.Next;
                    }
                    linced_list.AddAfter(node, item);
                }
            }
            Console.WriteLine($"Вставка в середину коллекции lincedlist : {watch.Elapsed.TotalMilliseconds}  мс");
            linced_list.Clear();
        }
        else if (addlast)
        {
            var watchfour = Stopwatch.StartNew();
            foreach (var item in ArrayString) linced_list.AddLast(item);
            Console.WriteLine($"Вставка в конец коллекции lincedlist : {watchfour.Elapsed.TotalMilliseconds}  мс");
            linced_list.Clear();
        }
    }
}
