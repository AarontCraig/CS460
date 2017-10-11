using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_app
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World");

            for(int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine("Args {0} : {1}", i, args[i]);
            }
            string[] myArgs = Environment.GetCommandLineArgs();
            Console.WriteLine(string.Join(", ", myArgs));

            SayHello(); */

            bool canIVote = true;
            Console.WriteLine("Biggest float : {0}, ", float.MaxValue);
            Console.WriteLine("Smallest float : {0}, ", float.MinValue);

            Console.ReadLine();
        }

        private static void SayHello()
        {
            string name = "";
            Console.Write("What is your name : ");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}", name);
        }
    }
}
