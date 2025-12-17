using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Utilities
{
    public class EmployeeFilter
    {
        public static List<Employee> FilterById(List<Employee> employees, int id)
        {
            List<Employee> filteredEmployeeRecords = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Id == id)
                {
                    filteredEmployeeRecords.Add(employee);
                }
            }
            
            return filteredEmployeeRecords;
        }
        
        public static List<Employee> FilterByName(List<Employee> employees, string name)
        {
            List<Employee> filteredEmployeeRecords = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Name.ToLower().Contains(name.ToLower()))
                {
                    filteredEmployeeRecords.Add(employee);
                }
            }
            
            return filteredEmployeeRecords;
        }
        
        public static List<Employee> FilterByRole(List<Employee> employees, Role role)
        {
            List<Employee> filteredEmployeeRecords = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Role == role)
                {
                    filteredEmployeeRecords.Add(employee);
                }
            }
            
            return filteredEmployeeRecords;
        }
        
        public static List<Employee> FilterByDepartment(List<Employee> employees, Department department)
        {
            List<Employee> filteredEmployeeRecords = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Department == department)
                {
                    filteredEmployeeRecords.Add(employee);
                }
            }
            
            return filteredEmployeeRecords;
        }
        
        public static List<Employee> FilterBySalary(List<Employee> employees, decimal minSalary, decimal maxSalary)
        {
            List<Employee> filteredEmployeeRecords = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Salary >= minSalary && employee.Salary <= maxSalary)
                {
                    filteredEmployeeRecords.Add(employee);
                }
            }
            
            return filteredEmployeeRecords;
        }
    }
}