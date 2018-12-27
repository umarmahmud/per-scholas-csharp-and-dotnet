using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

/*
 *	Use the Windows API functions EnumWindows and GetWindowThreadProcessId to list all of the Window processes on your desktop.

		Hint:  To get the address of a method (the first argument to EnumWindows), you’ll need to define a delegate with the appropriate signature.  
		If you are writing in Visual Basic, you will also need to use the Address Of (Links to an external site.)Links to an external site. operator.

		Hint:  Once you have the process id, use Process.GetProcessById to retrieve the needed process information.

		As for the ListProcesses exercise, write the application to output each unique window/process name and the number of instances running.  
		Order the output by the # running processes, descending.
*/

namespace ListDesktopWindowProcesses
{
    class Program
    {
        // delegate signature
        public delegate bool EnumWindowsDel(IntPtr hWnd, IntPtr lParam);
        private static Dictionary<string, int> _processDictionary;

        static void Main(string[] args)
        {
            EnumWindowsDel del = Callback;
            _processDictionary = new Dictionary<string, int>();

            // Console.WriteLine(EnumWindows(del, 0));
            EnumWindows(del, 0);

            var query = from i in _processDictionary
                        orderby i.Value descending
                        select i.Key;

            foreach (var i in query)
            {
                Console.WriteLine(i.ToString() + '\t' + _processDictionary[i].ToString());

            }

            // Console.WriteLine(EnumWindows((hWnd, lParam) => true, 1));

            // Console.WriteLine(processes[7].Threads.Count);
        }

        public static bool Callback(IntPtr hWnd, IntPtr lParam)
        {
            var processes = Process.GetProcesses();

            int threadId = GetWindowThreadProcessId(hWnd, out uint processId);

            for (var i = 0; i < processes.Count(); i++)
            {
                for (var j = 0; j < processes[i].Threads.Count; j++)
                {
                    if (processes[i].Threads[j].Id == threadId)
                    {
                        // Console.WriteLine(processes[i] + processes[i].Id.ToString());

                        string process = processes[i].ToString().Replace("System.Diagnostics.Process ", "").Replace("(", "").Replace(")", "");

                        if (_processDictionary.Keys.Contains(process))
                        {
                            _processDictionary[process] += 1;
                        }
                        else
                        {
                            _processDictionary.Add(process, 1);
                        }
                    }
                }
            }

            // Console.WriteLine(Process.GetProcessById(3360));
            // Console.WriteLine(GetWindowThreadProcessId(hWnd, out uint processId));
            // Console.WriteLine(hWnd);

            return true;
        }

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsDel cb, int ptr);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    }
}
