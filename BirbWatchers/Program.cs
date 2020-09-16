using System;
using System.Collections.Generic;
using System.Threading;

namespace BirbWatchers
{
	class Program
	{
		static void Main(string[] args)
		{
			List<BirdWatcher> boomers = new List<BirdWatcher>();
			Bird bird = new Bird();
			Random rand = new Random();

			for (int i = 0; i < 5; i++)
			{
				boomers.Add(new BirdWatcher(i, rand.Next() % 2 == 0 ? true : false));
				bird.BirdAction += boomers[i].ReactToBird;
			}

			bird.Run();
		}
	}

	class Bird
	{
		private string[] actions = { "flap", "sing", "fly" };
		public Action<string> BirdAction;

		public void Run()
		{
			Random rand = new Random();
			for (int i = 0; i < 5; i++)
			{
				BirdAction?.Invoke(actions[rand.Next(actions.Length)]);
				Thread.Sleep(1000);
			}
		}
	}

	class BirdWatcher
	{
		public bool IsDeaf { get; set; }
		public int ID {get; set;}

		public BirdWatcher(int i, bool isDeaf)
		{
			ID = i;
			IsDeaf = isDeaf;
		}

		public void ReactToBird(string action)
		{
			Console.Write($"{ID}: ");
			switch (action)
			{
				case "flap":
					Console.Write("Wow it's flyin'");
					break;
				case "fly":
					Console.Write("Goodbye");
					break;
				case "sing":
					if (!IsDeaf) Console.Write("Bootiful");
					break;
			}
			Console.WriteLine();
		}
	}
}
