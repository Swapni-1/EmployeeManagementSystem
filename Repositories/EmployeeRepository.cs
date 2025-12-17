using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employee.Id == employees[i].Id)
                {
                    employees[i] = employee;
                    return;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.RemoveAt(i);
                    return;
                }
            }
        }

        public Employee GetById(int id)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }

            return null;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }
    }
}

