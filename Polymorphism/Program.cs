using System;

namespace Polymorphism
{
	class Program
	{
		static void Main(string[] args)
		{
			Company company = new Company();
			company.HireNewEmployee(new FullTimeEMployee("John", 34502.5));
			company.HireNewEmployee(new PartTimeEmployee("Bob", 500.5, 15));
			Console.WriteLine(company.GetMonthtlySalaryTotal());
		}
	}

}