using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PrychicSoftware;
using SortItOut;

namespace TechChallangeRun
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortRun();
            PhysicRun();
        }
        static void SortRun()
        {
            List<string> list = new List<string>
            {

                "Zebra",//a 1
                "Lion",// i 7
                "Tiger",//e i 3
                "Tiger",//4
                "",//0
                "Elephent",//e (e)h  2
                "Mouse",//e m 6
                "Monkey"//e k 5
            };

            StringSorter sorter = new StringSorter(list);
            List<string> sortedList = sorter.Sort().ToList();
            foreach(var item in sortedList)
            {
                Console.WriteLine(item);
            }
            
        }
        static void PhysicRun()
        {
            var s = new Psychic(1, 100);
            while (true)
            {
                Console.WriteLine($"{s.CurrentGuess} between {s.LowerBound} and {s.UpperBound}");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        s.Lower();
                        break;
                    case ConsoleKey.UpArrow:
                        s.Higher();
                        break;
                    case ConsoleKey.Enter:
                        s.Correct();
                        break;
                }
            }
        }
    }
 
    

}
