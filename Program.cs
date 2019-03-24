using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Log.WriteError("The argument for the path to search for bots was not supplied", true);
                return;
            }

            var botImporter = new BotImporter(args[0]);
            botImporter.Start();

            Console.Read();
        }
    }
}
