using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_13_6_2_popular_words
{
    internal class WordFromNovel
    {
        public string? Name { get; set; }

        public int Number { get; set; }

        public WordFromNovel(int number, string name)
        {
            Name = name;
            Number = number;
        }
    }
}
