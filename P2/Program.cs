using System;

namespace P1
{
    class Solution
    {
        static void Main(string[] args)
        {
            string casenumber = Console.ReadLine();
            
            for (int c = 1; c <= Convert.ToInt32(casenumber); c++)
            {
                string size = Console.ReadLine();
                string sequenceA = Console.ReadLine();
                string sequenceB = "";

                for (int i = 0; i < sequenceA.Length; i++)
                {
                    if (sequenceA[i] == 'S')
                    {
                        sequenceB = sequenceB + "E";
                    }
                    else
                    {
                        sequenceB = sequenceB + "S";
                    }
                }

                Console.WriteLine($"Case #{c}: {sequenceB}");              
            }
        }        
    }
}
