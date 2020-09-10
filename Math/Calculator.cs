using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	class Calculator
	{
		public static int Sum(int a, int b)
		{
			return a + b;
		}

		public static int Sum(int[] a)
		{
			int s = 0;
			foreach (int x in a)
			{
				s += x;
			}
			return s;
		}

		public static int Max(int a, int b)
		{
			return a > b ? a : b;
		}
	}
}
