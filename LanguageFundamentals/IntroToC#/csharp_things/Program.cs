using System;
// To use lists and/or dictionaries:
using System.Collections.Generic;

namespace csharp_things
{
    class Program
    {
        //1. access modifier
        //2 (optional). static? 
        //3. Return type
        //4. function name and any arguments
        //  4a. like our variable declarations, any arguments that a function is built to take
        //      must also be declared as a type
        //  4b. arguments must be run-time constants
        public static int MyAge()
        {
            return 29;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // integers
            int x = 1000000000;
            long BigNum = 100000000000000000;
            // non-integer numbers
            double z = 11.6;
            // strings
            string word = "bologna";
            // characters
            char character = '!';

            // arrays
            int[] Nums = new int[5];

            for(int i = 0; i < Nums.Length; i++)
            {
                System.Console.WriteLine(Nums[i]);
            }

            // create an empty list
            List<int> MyList = new List<int>();
            // and THEN add the values
            MyList.Add(5);
            MyList.Add(9);
            MyList.Add(11);

            // or
            // prepopulate the list on creation
            List<int> PrePop = new List<int>{5, 9, 11};

            int x = 10;

            if(MyList.Contains(5))
            {
                System.Console.WriteLine("Yep!");
            }
            else
            {
                System.Console.WriteLine("Nope!");
            }

            // if/else if/else
            // if(some condition)
            // {
            //     do thing
            // }
            // else if(other condition)
            // {
            //     do other thing
            // }
            // else
            // {
            //     do third thing
            // }

            foreach(int n in PrePop)
            {
                System.Console.WriteLine(n);
            }


            Console.WriteLine(PrePop[1]);
            Console.WriteLine(MyAge());
        }
    }
}
