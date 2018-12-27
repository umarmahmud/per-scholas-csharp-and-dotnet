using System;
using System.Text;

// Exercise:  Use a loop to generate a string of the alphabet (lower-case):  "abcdefghijklmnopqrstuvwxyz"

namespace Alphabet
{
	class Program
	{
		static void Main(string[] args)
		{
            StringBuilder sb = new StringBuilder(26);

            for (int i = 97; i < 123; i++)
            {
                sb.Append(Convert.ToChar(i));
            }

            Console.WriteLine(sb.ToString());
        }
	}
}
