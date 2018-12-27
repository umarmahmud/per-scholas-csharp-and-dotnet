using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppStarter
{
	class Program
	{
		// Write a Console application that starts another application, optionally passing arguments to it.

		// Your Console application will require that at least one argument is passed to it - the path to the executable that it will start.
		// If additional arguments are passed to your console application, those will in turn be passed to the executable that is being started.

		// Running your program like this:
		// AppStarter "c:\windows\system32\notepad.exe" "c:\Users\Joseph\Documents\Jabberwocky.txt"
		// Would cause notepad to run with Jabberwocky.txt opened.
	
		static int Main(string[] args)
		{
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter at least one argument");
                return -1;
            }
            else if (args.Length == 1)
            {
                ProcessStartInfo pInfo = new ProcessStartInfo(args[0]);
                Process.Start(pInfo);
                return 0;
            }
            else
            {
                for (var i = 1; i < args.Length; i++)
                {
                    ProcessStartInfo pInfo = new ProcessStartInfo(args[0]);
                    pInfo.Arguments = args[i];
                    Process.Start(pInfo);
                }
                return 0;
            }
        }
	}
}
