using System;

namespace Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Even:");
			PrintEven(10);
			Console.WriteLine("Odd:");
			PrintOdd(10);
			Console.WriteLine("Mod Range:");
			PrintModRange(10, 3);
		}

		static void PrintEven(int x)
		{
			for (int i = 0; i <= x; i += 2)
			{
				Console.WriteLine(i);
			}
		}

		static void PrintOdd(int x)
		{
			for (int i = 1; i <= x; i += 2)
			{
				Console.WriteLine(i);
			}
		}

		static void PrintModRange(int x, int y)
		{
			for (int i = 0; i <= x; i++)
			{
				if (i % y == 0)
					Console.WriteLine(i);
			}
		}
	}
}
