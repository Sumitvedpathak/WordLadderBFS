using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderBFS
{
    struct Item
    {
        public string Word;
        public bool visited;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> dictionary = new List<Item>();
            dictionary.Add(new Item { Word = "CAT", visited = true });
            dictionary.Add(new Item { Word = "BAT", visited = false });
            dictionary.Add(new Item { Word = "COT", visited = false });
            dictionary.Add(new Item { Word = "COG", visited = false });
            dictionary.Add(new Item { Word = "COW", visited = false });
            dictionary.Add(new Item { Word = "RAT", visited = false });
            dictionary.Add(new Item { Word = "BUT", visited = false });
            dictionary.Add(new Item { Word = "CUT", visited = false });
            dictionary.Add(new Item { Word = "DOG", visited = false });
            dictionary.Add(new Item { Word = "WEB", visited = false });
            string start = "CAT";
            string end = "DOG";
            List<string> finalStr = new List<string>();

            List<string> traverseList = new List<string>();
            foreach (Item word in dictionary)
                traverseList.Add(word.Word);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            string finalQueueWord = string.Empty;
            while (queue.Count != 0)
            {
                string wordToCheck = queue.Dequeue();
                bool endWordFound = false;
                foreach (String word in traverseList)
                {
                    if (!dictionary.Single(q => q.Word.Equals(word)).visited)
                    {
                        int found = 0;
                        for (int j = 0; j < wordToCheck.Count(); j++)
                        {
                            if (wordToCheck[j] == word[j])
                                found++;
                        }
                        if (found >= 2)
                        {
                            if (!word.Equals(end))
                            {
                                //finalStr.Add();
                                Item visitedItem = dictionary.Where(q => q.Word.Equals(word)).FirstOrDefault();
                                visitedItem.visited = true;
                                int index = dictionary.FindIndex(q => q.Word.Equals(word));
                                dictionary.RemoveAt(index);
                                dictionary.Insert(index, visitedItem);
                                queue.Enqueue(word);
                                Console.Write(word + "->");
                            }
                            else
                            {
                                endWordFound = true;
                                break;
                            }
                        }
                    }
                }
                if (endWordFound)
                    break;
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
