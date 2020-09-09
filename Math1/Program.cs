using MathLib;
using System;

namespace Math1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Calculator.Sum(2, 2));
			int[] a = { 1, 2, 3 };
			Console.WriteLine(Calculator.Sum(a));

			Console.WriteLine(Calculator.Max(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));
		}
	}
}
