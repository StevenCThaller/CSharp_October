using System;
using System.Collections.Generic;

namespace BoxUnbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> MyObjects = new List<object>
            {
                "String 1",
                "String 2",
                4,
                'y',
                false,
                // "hello",
                9
            };



            
            if(MyObjects[2] is int && MyObjects[5] is int){
                int sum = Convert.ToInt32(MyObjects[2]) + (int)MyObjects[5];
                System.Console.WriteLine(sum);
            } else {
                System.Console.WriteLine("You can't add those two things together, they're not both numbers.");
            }


            Dictionary<string, object> MyDictionary = new Dictionary<string, object>();

            MyDictionary.Add("FirstName", "Cody");
            MyDictionary.Add("Age", 29);
            MyDictionary.Add("HasDegree", true);

            System.Console.WriteLine(MyDictionary["FirstName"]);

            MyDictionary["FirstName"] = "Steven";

            System.Console.WriteLine(MyDictionary["FirstName"]);



            int[] number = {1,2,3,4,5};

            Dictionary<string,string> dez = new Dictionary<string,string>();

            foreach(var kvp in MyDictionary)
            {
                System.Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }

            MyFunctions fun = new MyFunctions();

            fun.MyFunction1();
        }
    }
}