namespace EmployeeManagementSystem.Models
{
    public class Aggregates
    {
        public int EmployeeCount { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public decimal AverageSalary { get; set; }
        public decimal SumOfSalaries { get; set; }
    }
}