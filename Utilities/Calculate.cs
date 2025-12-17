using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Utilities
{
    public class Calculate
    {
        public static Aggregates Aggregates(List<Employee> employees)
        {
            decimal sumOfSalaries = 0;
            decimal maximumSalary = decimal.MinValue;
            decimal minimumSalary = decimal.MaxValue;
            
            Aggregates aggregates = new Aggregates();
            
            foreach (var employee in employees)
            {
                sumOfSalaries += employee.Salary;
                
                if (employee.Salary > maximumSalary)
                {
                    maximumSalary = employee.Salary;
                }

                if (employee.Salary < minimumSalary)
                {
                    minimumSalary = employee.Salary;
                }
            }
            
            aggregates.EmployeeCount = employees.Count;
            aggregates.SumOfSalaries =  sumOfSalaries;
            aggregates.AverageSalary = sumOfSalaries / employees.Count;
            aggregates.MaximumSalary = maximumSalary;
            aggregates.MinimumSalary = minimumSalary;
            
            return aggregates;
        }
    }
}