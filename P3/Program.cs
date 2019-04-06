using System;
using System.Collections.Generic;
using System.Linq;

namespace P1
{
    class Solution
    {
        static void Main(string[] args)
        {           

            string casenumber = Console.ReadLine();

            for (int c = 1; c <= Convert.ToInt32(casenumber); c++)
            {
                string settings = Console.ReadLine();
                var maxPrimeValue = settings.Split(' ').ToList();

                string cypherSetSingleString = Console.ReadLine();
                var cypherSetStrings = cypherSetSingleString.Split(' ').ToList();
                var cypherSet = cypherSetStrings.Select(long.Parse).ToList();
                
                var primes = new List<long>();
                GeneratePrimes(int.Parse(maxPrimeValue[0]), ref primes);

                var letterCodes = new List<long>();
                var firstPairs = new List<Tuple<long, long>>();

                // First pair finder
                foreach (var prime in primes)
                {
                    if ((cypherSet[0] % prime) == 0)
                    {
                        //Console.WriteLine($"First detected prime number = {prime}");
                        var second = cypherSet[0] / prime;

                        firstPairs.Add(new Tuple<long, long>(prime, second));

                        //Console.WriteLine($"{cypherSet[0]} = {prime} * {second}");
                    }
                }

                // Following pairs
                int pairIndex = firstPairs.Count - 1;
                bool retry = true;
                cypherSet.RemoveAt(0); //first encrypted value is already calculated

                while (retry)
                {
                    //Console.WriteLine("Left: " + firstPairs[pairIndex].Item2);
                    //Console.WriteLine("Right: " + firstPairs[pairIndex].Item1);

                    var leftElement = firstPairs[pairIndex].Item2;
                    letterCodes.Add(firstPairs[pairIndex].Item1);
                    letterCodes.Add(firstPairs[pairIndex].Item2);

                    long rightElement = 0;
                    foreach (var cypherValue in cypherSet)
                    {
                        if ((cypherValue % leftElement) == 0)
                        {
                            rightElement = cypherValue / leftElement;
                            letterCodes.Add(rightElement);

                            //Console.WriteLine($"{cypherValue} = {leftElement} * {rightElement}");

                            leftElement = rightElement;
                        }
                        else
                        {
                            //Console.WriteLine("Dead End. Need to start with another prime number");
                            letterCodes = new List<long>();
                            pairIndex = pairIndex - 1;
                            retry = true;
                            break;
                        }

                        retry = false;
                    }

                    
                }
                

                // Sequence of numbers
                //Console.WriteLine(String.Join(" ", letterCodes));

                // Sequence of letters
                var letters = ConvertPrimesToLetters(letterCodes);

                Console.WriteLine($"Case #{c}: {letters}");
            }
        }

        private static string ConvertPrimesToLetters(List<long> letterCodes)
        {
            List<long> origin = new List<long>(letterCodes);
            string answer = "";

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            //Console.WriteLine(letterCodes.Count);
            var noduplicates = letterCodes.Distinct().ToList();

            noduplicates.Sort();
            //Console.WriteLine(letterCodes.Count);

            foreach (var l in origin)
            {
                int i = noduplicates.IndexOf(l);
                answer = answer + alpha[i].ToString();
            }

            return answer;
        }

        private static void GeneratePrimes(int n, ref List<long> primes)
        {
            for (int i = 2; i <= n; i++)
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                    //Console.Write(i + " ");
                }
            }
            //Console.WriteLine($"");
        }


        static bool isPrime(int n)
        {
            // Corner cases 
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;

            // This is checked so  
            // that we can skip 
            // middle five numbers 
            // in below loop 
            if (n % 2 == 0 ||
                n % 3 == 0)
                return false;

            for (int i = 5;
                     i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }
    }
}
