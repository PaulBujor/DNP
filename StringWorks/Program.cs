using System;

namespace ABBA
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(MakeAbba("A", "b"));
			Console.WriteLine(Surround("[[]]", "hello"));
			Console.WriteLine(OuterSubstring("Chocolate", 3));
		}

		static string MakeAbba(string a, string b)
		{
			return $"{a}{b}{b}{a}";
		}

		static string Surround(string outer, string inner)
		{
			return $"{outer.Substring(0, 2)}{inner}{outer.Substring(2)}";
		}

		static string OuterSubstring(string s, int x)
		{
			return $"{s.Substring(0, x)}{s.Substring(s.Length - x)}";
		}
	}
}
