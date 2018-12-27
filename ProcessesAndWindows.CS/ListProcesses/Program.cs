using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListProcesses
{
    class Program
    {
        /*
		 * Write a Console application that lists the names of all active processes.
		 * 
		 * You may notice that many processes occur numerous times.
		 * 
		 * Modify the application to output each unique process name and the number of instances running.  Order the output by the # running processes, descending.
		*/

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            Dictionary<string, int> processesDictionary = new Dictionary<string, int>();

            foreach (Process p in processes)
            {
                string process = p.ToString().Replace("System.Diagnostics.Process ", "").Replace("(", "").Replace(")", "");
                // string process = p.ToString();
                if (processesDictionary.Keys.Contains(process))
                {
                    processesDictionary[process] += 1;
                }
                else
                {
                    processesDictionary.Add(process, 1);
                }
            }
            var query = from entry in processesDictionary
                        orderby entry.Value descending
                        select entry.Key;

            /*
            foreach (KeyValuePair<string, int> entry in processesDictionary)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine(entry.Value);
            }
            */

            foreach (var i in query)
            {
                Console.WriteLine("{0}\t{1}", i, processesDictionary[i]);
            }
        }
    }
}
