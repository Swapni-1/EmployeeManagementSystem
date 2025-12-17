using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Utilities
{
    public static class Calculate
    {
        public static Aggregates CalculateAggregates(List<Employee> employees,Aggregates aggregates)
        {
            decimal sumOfSalaries = 0;
            decimal maximumSalary = 0;
            decimal minimumSalary = 0;
            
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