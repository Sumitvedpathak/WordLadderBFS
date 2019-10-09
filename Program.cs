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
            dictionary.Add(new Item { Word = "DAMP", visited = true });
            dictionary.Add(new Item { Word = "LIME", visited = false });
            dictionary.Add(new Item { Word = "LIKE", visited = false });
            dictionary.Add(new Item { Word = "LAMP", visited = false });
            dictionary.Add(new Item { Word = "LIMP", visited = false });
            dictionary.Add(new Item { Word = "LINK", visited = false });

            string start = "DAMP";
            string end = "LIKE";

            //This list will add all possible combination of travelsal nodes.
            List<string> finalStr = new List<string>();

            //Copy list into another list to iterate each item.
            List<string> traverseList = new List<string>();
            foreach (Item word in dictionary)
                traverseList.Add(word.Word);

            //Add the start word in the queue
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            //This variable is used to form the shortest path.
            string finalQueueWord = string.Empty;
            while (queue.Count != 0)
            {
                //Remove the top from the queue.
                string wordToCheck = queue.Dequeue();

                //This is to form the word
                if (finalStr.FindIndex(q => q.Contains(wordToCheck)) != -1)
                    finalQueueWord = finalStr.Single(q => q.Contains(wordToCheck));
                else
                    finalQueueWord += wordToCheck + "-";

                //To check if the end word is found need to stop the processing.
                bool endWordFound = false;
                foreach (String word in traverseList)
                {
                    //To check if the word is visited. If not then process else do not process
                    if (!dictionary.Single(q => q.Word.Equals(word)).visited)
                    {
                        //Check if word is formed after replacing a single character and that too exists in dictionary.
                        int found = 0;
                        for (int j = 0; j < wordToCheck.Count(); j++)
                        {
                            if (wordToCheck[j] == word[j])
                                found++;
                        }

                        // If found in dictionary. Then mark it as visited and put it in queue
                        if (found >= (wordToCheck.Length - 1))
                        {
                            //If end word found then break the loops.
                            if (!word.Equals(end))
                            {
                                finalStr.Add(finalQueueWord + word + "-");
                                Item visitedItem = dictionary.Where(q => q.Word.Equals(word)).FirstOrDefault();
                                visitedItem.visited = true;
                                int index = dictionary.FindIndex(q => q.Word.Equals(word));
                                dictionary.RemoveAt(index);
                                dictionary.Insert(index, visitedItem);
                                queue.Enqueue(word);
                            }
                            else
                            {
                                endWordFound = true;
                                finalStr.Add(finalQueueWord + word + "-");
                                break;
                            }
                        }
                    }
                }
                // break while loop if end word found.
                if (endWordFound)
                    break;
                Console.WriteLine();
            }
            Console.WriteLine(finalStr.Single(p => p.Length == finalStr.Max(q => q.Length)));
            Console.ReadLine();
        }
    }
}
