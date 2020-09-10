using System;
using System.Collections.Concurrent;

namespace TimeStruct
{
	public struct Time
	{
		private int minutes;

		public int Hour { get => (minutes / 60) % 24; }
		public int Minute { get => minutes % 60; set { minutes = value < 0 ? value + 1440 : value % 1440; } }


		public Time(int hours, int minutes)
		{
			this.minutes = minutes + 60 * hours;
		}

		public void AddMinutes(int minutes)
		{
			this.minutes += minutes;
		}

		public void SubtractMinutes(int minutes)
		{
			this.minutes -= minutes;
		}

		public override string ToString()
		{
			return $"{Hour}:{Minute}";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Time time = new Time(22, 57);
			Console.WriteLine(time);
			time.AddMinutes(63);
			Console.WriteLine(time);
			time.SubtractMinutes(63);
			Console.WriteLine(time);
		}
	}
}
