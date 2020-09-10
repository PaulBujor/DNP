using System.Collections.Generic;

namespace Polymorphism
{
	public class Company
	{
		private List<Employee> employees;

		public Company()
		{
			employees = new List<Employee>();
		}

		public double GetMonthtlySalaryTotal()
		{
			double total = 0;
			foreach (Employee employee in employees)
			{
				total += employee.GetMonthlySalary();
			}
			return total;
		}

		public void HireNewEmployee(Employee employee)
		{
			employees.Add(employee);
		}
}
}

