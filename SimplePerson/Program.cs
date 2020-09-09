using System;

namespace SimplePerson
{
	class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person();
			person.Name = "Bob";
			person.Introduce();
		}
	}

	class Person
	{
		public string Name
		{
			get; set;
		}

		public void Introduce()
		{
			Console.WriteLine("Hi, I am " + Name);
		}
	}
}
