using System;

namespace ArrayWorks
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 7, 2, 10, 9 };
			Console.WriteLine(BigDiff(arr));

			int[] arr2 = { 1, 1, 1, 1, 1 };
			Console.WriteLine(CountClumps(arr2));
		}

		static int BigDiff(int[] arr)
		{
			int maxDiff = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				if (Math.Abs(arr[i] - arr[i + 1]) > maxDiff)
					maxDiff = Math.Abs(arr[i] - arr[i + 1]);
			}
			return maxDiff;
		}

		static int CountClumps(int[] arr)
		{
			int counter = 1;
			int clumpCounter = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] == arr[i - 1])
					counter++;
				else
				{
					if (counter >= 2)
						clumpCounter++;
					else
						counter = 1;
				}
			}

			//handles scenario when all number are the same
			if (clumpCounter == 0 && counter >= 2)
				clumpCounter = 1;
			return clumpCounter;
		}
	}
}
