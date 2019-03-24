using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotImporter
{
    class Log
    {
        public static void WriteError(string v, bool block = false)
        {
            Console.WriteLine("[ERROR] " + v);

            if (block)
                Console.Read();

        }

        public static void WriteWarning(string v, bool block = false)
        {
            Console.WriteLine("[WARN] " + v);


            if (block)
                Console.Read();
        }
    }
}
