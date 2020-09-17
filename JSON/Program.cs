using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSON
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Person> people = new List<Person>();
			people.Add(new Person("John", "1", 15, 1.80, false, 'm', new string[] { "music", "cars" }));
			people.Add(new Person("John", "2", 19, 1.80, false, 'm', new string[] { "music", "sex" }));
			people.Add(new Person("John", "3", 25, 1.80, true, 'm', new string[] { "photos", "cars" }));

			string serialized = JsonSerializer.Serialize(people, new JsonSerializerOptions
			{
				WriteIndented = true
			});
			Console.WriteLine(serialized);

			StoreObjects(people);

			List<Person> readpeople = ReadObjects();

			foreach (var person in readpeople)
			{
				Console.WriteLine(person);
			}
		}

		private static void StoreObjects(List<Person> people)
		{
			using (StreamWriter file = new StreamWriter("People.txt"))
			{
				foreach (var person in people)
				{
					file.WriteLine(JsonSerializer.Serialize(person));
				}
			}
		}

		private static List<Person> ReadObjects()
		{
			List<Person> people = new List<Person>();

			using (StreamReader file = new StreamReader("People.txt"))
			{
				string str;
				while((str = file.ReadLine()) != null) {
					people.Add(JsonSerializer.Deserialize<Person>(str));
				}
			}

			return people;
		}
	}

	//[Serializable]
	class Person
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public int age { get; set; }
		public double height { get; set; }
		public bool isMarried { get; set; }
		public char sex { get; set; }
		public string[] hobbies { get; set; }

		public Person() { }

		public Person(string firstName, string lastName, int age, double height, bool isMarried, char sex, string[] hobbies)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.age = age;
			this.height = height;
			this.isMarried = isMarried;
			this.sex = sex;
			this.hobbies = hobbies;
		}

		public override string ToString()
		{
			return lastName;
		}
	}
}
