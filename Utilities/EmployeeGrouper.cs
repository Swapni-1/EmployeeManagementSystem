using System.Collections.Generic;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Utilities
{
    public class EmployeeGrouper
    {
        public static Dictionary<string,List<Employee>> GroupByRole(List<Employee> employees)
        {
            Dictionary<string,List<Employee>> groups = new Dictionary<string,List<Employee>>();
            foreach (Employee employee in employees)
            {
                if (!groups.ContainsKey(employee.Role.ToString()))
                {
                    groups[employee.Role.ToString()] = new List<Employee>();
                }
                
                groups[employee.Role.ToString()].Add(employee);
            }
            return groups;
        }
        
        public static Dictionary<string,List<Employee>> GroupByDepartment(List<Employee> employees)
        {
            Dictionary<string, List<Employee>> group = new Dictionary<string, List<Employee>>();

            foreach (Employee employee in employees)
            {
                if (!group.ContainsKey(employee.Department.ToString()))
                {
                    group[employee.Department.ToString()].Add(employee);
                }
                group[employee.Department.ToString()].Add(employee);
            }
            return group;
        }
    }
}