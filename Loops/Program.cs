using System;
using Loops.Context;

namespace Loops
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var data = new DataContext();
            foreach (var family in data.Families)
            {
                Console.WriteLine(family.Nickname);                
            }


        }

    }
}
