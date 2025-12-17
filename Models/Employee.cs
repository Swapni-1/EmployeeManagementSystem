namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }
    }

    public enum Role
    {
        Employee = 1,
        Manager = 2,
        Intern = 3
    }

    public enum Department
    {
        HR = 1,
        Finance = 2,
        Engineering = 3,
        Sales = 4,
        Marketing = 5
    }
}