using System;
using System.Collections.Generic;

namespace CarPredicates
{
	class Program
	{
		static void Main(string[] args)
		{
			//conditions
			string color = "Blue";

			List<Car> cars = new List<Car>();
			for (int i = 0; i < 5; i++)
			{
				cars.Add(Car.generateCar());
				Console.WriteLine(cars[i]);
			}

			var blueCars = cars.FindAll(c => c.Color == color);

			Console.WriteLine("______________");

			foreach (Car car in blueCars)
			{
				Console.WriteLine(car);
			}

			var bigEngined = cars.FindAll(c => c.EngineSize >= 4);

			Console.WriteLine("______________");

			foreach (Car car in bigEngined)
			{
				Console.WriteLine(car);
			}

			var ecoBoxes = cars.FindAll(c => c.FuelEconomy <=4);

			Console.WriteLine("______________");

			foreach (Car car in ecoBoxes)
			{
				Console.WriteLine(car);
			}

			var manuals = cars.FindAll(c => c.IsManualShift);

			Console.WriteLine("______________");

			foreach (Car car in manuals)
			{
				Console.WriteLine(car);
			}
		}
	}


	class Car
	{
		public string Color { get; set; }
		public double EngineSize { get; set; }
		public double FuelEconomy { get; set; }
		public bool IsManualShift { get; set; }

		public Car(string color, double engineSize, double fuelEconomy, bool isManualShift)
		{
			Color = color;
			EngineSize = engineSize;
			FuelEconomy = fuelEconomy;
			IsManualShift = isManualShift;
		}

		public override string ToString()
		{
			return $"{Color} {EngineSize: 0.00}L {FuelEconomy: 0.00}l/100km {(IsManualShift ? "Manual" : "Auto")}";
		}

		public static Car generateCar()
		{
			Random rand = new Random();
			string[] colorSet = { "Blue", "Black", "Gray", "Yellow", "Green", "Red" };
			string color = colorSet[rand.Next(colorSet.Length)];
			double engineSize = rand.NextDouble() * 5;
			double fuelEconomy = engineSize * 2;
			bool isManual = rand.Next() % 2 == 0 ? true : false;
			return new Car(color, engineSize, fuelEconomy, isManual);
		}
	}
}
