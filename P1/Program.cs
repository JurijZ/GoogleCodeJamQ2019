using System;

namespace P1
{
    class Solution
    {
        static void Main(string[] args)
        {
            var j = 1;
            string casenumber = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "")
            {
                if (input.Contains("4"))
                {
                    Int64 second = 0;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '4')
                        {
                            second = second + Getdec(input.Length, i);
                        }
                    }

                    var pirmas = Convert.ToInt64(input) - second;

                    Console.WriteLine($"Case #{j}: {pirmas} {second}");
                }

                if (j >= Convert.ToInt32(casenumber))
                {
                    return;
                }
                input = Console.ReadLine();
                j++;
            }           
        }

        public static Int64 Getdec(int len, int indexer)
        {
            int zeros = len - indexer - 1;

            return (Int64)Math.Pow(10, zeros);
        }
    }
}
