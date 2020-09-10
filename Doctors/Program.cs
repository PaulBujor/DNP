using System;
using System.Collections.Generic;
using System.Threading;

namespace Doctors
{
	class Program
	{
		static void Main(string[] args)
		{
			WaitingRoom wr = new WaitingRoom();
			List<Patient> patients = new List<Patient>();
			for (int i = 0; i < 5; i++)
			{
				patients.Add(new Patient(wr));
				if(i == 0) new Thread(() => wr.RunWaitingRoom()).Start();
			}
		}
	}

	public class WaitingRoom
	{
		public Action<int> NumberChange;
		private int currentNumber;
		private int ticketCount;

		public WaitingRoom()
		{
			currentNumber = 0;
			ticketCount = 0;
		}

		public void RunWaitingRoom()
		{
			while (currentNumber < ticketCount)
			{
				Console.WriteLine($"Ding! Patient {++currentNumber} can now enter.");
				NumberChange?.Invoke(currentNumber);
				Thread.Sleep(1000);
			}
		}

		public int DrawNumber()
		{
			return ++ticketCount;
		}
	}

	public class Patient
	{
		private int numberInQueue;

		public Patient(WaitingRoom wr)
		{
			numberInQueue = wr.DrawNumber();
			Console.WriteLine($"Patient {numberInQueue} enters waiting room");
			wr.NumberChange += ReactToNumber;
		}

		public void ReactToNumber(int ticketNumber)
		{
			if (numberInQueue >= ticketNumber)
				Console.WriteLine($"Patient {numberInQueue} {(ticketNumber == numberInQueue ? "enters the room." : "stays and playes with the phone.")}");
		}
	}
}
