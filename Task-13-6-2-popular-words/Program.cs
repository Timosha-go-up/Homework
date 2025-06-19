using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Task_13_6_2_popular_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь к файлу
            var path = "C:\\Users\\Roman-PC\\Downloads\\input.txt";

            var fileInfo = new FileInfo(path);

            using StreamReader sr = fileInfo.OpenText();

            //считать содержимое в переменную
            var text = sr.ReadToEnd();

            //исключить знаки препинания
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            
            string[] Words = noPunctuationText.Split([' ', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
          
            //сортировка по алфавиту массива слов 
            Array.Sort(Words);

            List<WordFromNovel> UniqueWordsFromNovel = [];
            
            // получение количества повторений каждого уникального слова и создание списка из них 
            CreateUniqueListWords(UniqueWordsFromNovel, Words);


            //Сортировка уникальных слов по количеству повторений
            UniqueWordsFromNovel.Sort((p1, p2) =>
            {
                return p1.Number - p2.Number;
            });
            
            Console.WriteLine("10 самых популярных слов в романе Обломов");

            for (int i = UniqueWordsFromNovel.Count - 10; i < UniqueWordsFromNovel.Count; i++)
            {
            Console.WriteLine($"{UniqueWordsFromNovel[i].Number}\tко-во повторений слова\t{UniqueWordsFromNovel[i].Name}");
            } 

            // получить доступ к  существующему либо создать новый
            // StreamWriter file = new StreamWriter("C:\\Users\\Roman-PC\\Desktop\\TestFile.txt");
            // записать в него
            // foreach (WordFromNovel str in UniqueWordsFromNovel) {file.WriteLine(str.Number + "\t\t\t" + str.Name); }            
            // закрыть для сохранения данных
            // file.Close();

            Console.ReadKey();
        }

        static void CreateUniqueListWords(List<WordFromNovel> uniqueWords, string[]Words)
        {
            int count = 1;

            for (int i = 0; i < Words.Length - 1; i++)
            {
                if (Words[i] == Words[i + 1]) count++;

                else
                {
                    uniqueWords.Add(new(count, Words[i]));

                    count = 1;
                }
            }
        }
    }
}
