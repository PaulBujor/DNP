namespace Polymorphism
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract double GetMonthlySalary(); 

        public Employee(string name) {
            Name = name;
        }
    }

    public class PartTimeEmployee : Employee {
        public double HourlyWage { get; set; }
        public int HoursPerMonth { get; set; }

        public override double GetMonthlySalary() {
            return HourlyWage * HoursPerMonth;
        }

        public PartTimeEmployee (string name, double hourlyWage, int hoursPerMonth) : base(name) {
            HourlyWage = hourlyWage;
            HoursPerMonth = hoursPerMonth;
        }
    }

    public class FullTimeEMployee : Employee {
        public double MonthlySalary { get; set; }

        public override double GetMonthlySalary() {
            return MonthlySalary;
        }

        public FullTimeEMployee(string name, double monthlySalary) : base(name) {
            MonthlySalary = monthlySalary;
        }
    }
}