using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{

    class Program
    {
        const int ANSWER_SIZE = 4;

        static IEnumerable<string> Permutations(int size)
        {
            if (size > 0)
            {
                foreach (string s in Permutations(size - 1))
                    foreach (char n in "0123456789")
                        if (!s.Contains(n))
                            yield return s + n;
            }
            else
                yield return "";
        }

        static IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            Random random = new Random();
            List<T> list = source.ToList();
            while (list.Count > 0)
            {
                int ix = random.Next(list.Count);
                yield return list[ix];
                list.RemoveAt(ix);
            }
        }

        public static Dictionary<int, int> CompareNumbers(string TargetNumber, string CompareNumber)
        {
            int A = 0;
            int B = 0;
            for (int i = 0; i < 4; i++)
            {
                if (TargetNumber[i] == CompareNumber[i])
                    A++;
                for (int j = 0; j < 4; j++)
                {
                    if (TargetNumber[i] == CompareNumber[j] && i != j)
                        B++;
                }
            }
            Dictionary<int, int> bullAndCows = new Dictionary<int, int>();
            bullAndCows.Add(A, B);
            return bullAndCows;
        }

        static bool ReadBullsCows(out int bulls, out int cows)
        {
            string[] input = Console.ReadLine().Split(',').ToArray();
            bulls = cows = 0;
            if (input.Length < 2)
                return false;
            else
                return int.TryParse(input[0], out bulls)
                    && int.TryParse(input[1], out cows);
        }
        static IEnumerable<T> GenerateRandomNumber<T>(IEnumerable<T> source)
        {
            Random random = new Random();
            List<T> list = source.ToList();
            return list;            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bulls and Cows");
            Console.WriteLine("==============");
            Console.WriteLine();
            List<string> listUniqueNumbers = GenerateRandomNumber(Permutations(ANSWER_SIZE)).ToList();
            List<int> statistics = new List<int>();
            foreach (var num in listUniqueNumbers)
            {
                string numbers = string.Join("",num);
                List<string> answers = Shuffle(Permutations(ANSWER_SIZE)).ToList();
                int counter = 0;
                while (answers.Count > 1)
                {
                    counter++;
                    string guess = answers[0];
                    var dictionaryBullandCows = CompareNumbers(guess, numbers);
                    //Console.WriteLine("My guess is {0}. How many bulls, cows? ", guess);
                    int bulls = dictionaryBullandCows.Keys.FirstOrDefault();
                    int cows = dictionaryBullandCows.Values.FirstOrDefault();

                    //if (!ReadBullsCows(out bulls, out cows))
                    //    Console.WriteLine("Sorry, I didn't understand that. Please try again.");
                    //else
                    
                    for (int ans = answers.Count - 1; ans >= 0; ans--)
                    {
                        
                        int tb = 0, tc = 0;
                        for (int ix = 0; ix < ANSWER_SIZE; ix++)
                            if (answers[ans][ix] == guess[ix])
                                tb++;
                            else if (answers[ans].Contains(guess[ix]))
                                tc++;
                        if ((tb != bulls) || (tc != cows))
                            answers.RemoveAt(ans);
                    }
                    if (answers.Count == 1)
                    {
                        //Console.WriteLine("Hooray! The answer is {0}!, Counter {1}", answers[0], counter);
                        statistics.Add(counter);
                        //Console.ReadLine();

                    }

                    //else
                        //Console.WriteLine("No possible answer fits the scores you gave.");
                }
                

            }
            Console.WriteLine($"Guees with 1 - {statistics.Where(x => x == 1).Count()}");
            Console.WriteLine($"Guees with 2 - {statistics.Where(x => x == 2).Count()}");
            Console.WriteLine($"Guees with 3 - {statistics.Where(x => x == 3).Count()}");
            Console.WriteLine($"Guees with 4 - {statistics.Where(x => x == 4).Count()}");
            Console.WriteLine($"Guees with 5 - {statistics.Where(x => x == 5).Count()}");
            Console.WriteLine($"Guees with 6 - {statistics.Where(x => x == 6).Count()}");
            Console.WriteLine($"Guees with 7 - {statistics.Where(x => x == 7).Count()}");
            Console.WriteLine($"Guees with 8 - {statistics.Where(x => x == 8).Count()}");
            Console.WriteLine($"Guees with 9 - {statistics.Where(x => x == 9).Count()}");
            Console.WriteLine($"Guees with 10 - {statistics.Where(x => x == 10).Count()}");
            Console.WriteLine($"Guees with 11 - {statistics.Where(x => x == 11).Count()}");
            Console.WriteLine($"Guees with 12 - {statistics.Where(x => x == 12).Count()}");
            Console.WriteLine($"Guees with 13 - {statistics.Where(x => x == 13).Count()}");
            Console.WriteLine($"Guees with 14 - {statistics.Where(x => x == 14).Count()}");
            Console.WriteLine($"Guees with 15 - {statistics.Where(x => x == 15).Count()}");
            Console.WriteLine($"Guees with 16 - {statistics.Where(x => x == 16).Count()}");
            Console.ReadLine();
        }

    }
}



