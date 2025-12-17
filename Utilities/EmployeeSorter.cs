using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Utilities
{
    public class EmployeeSorter
    {
        public static void SortById(List<Employee> employees,int sortingOrder)
        {
            for (int i = 0; i < employees.Count - 1; i++) {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    switch (sortingOrder)
                    {
                        case 1:
                            if (employees[i].Id > employees[j].Id)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        case 2:
                            if (employees[i].Id < employees[j].Id)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid sorting order");
                            break;
                    }
                    
                }
            }
        }
        
        public static void SortByName(List<Employee> employees,int sortingOrder)
        {
            for (int i = 0; i < employees.Count - 1; i++) {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    switch (sortingOrder)
                    {
                        case 1:
                            if (string.Compare(employees[i].Name, employees[j].Name) > 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        case 2:
                            if (string.Compare(employees[i].Name, employees[j].Name) < 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid sorting order");
                            break;
                    }
                    
                }
            }
        }
        
        public static void SortByRole(List<Employee> employees,int sortingOrder)
        {
            for (int i = 0; i < employees.Count - 1; i++) {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    switch (sortingOrder)
                    {
                        case 1:
                            if (string.Compare(employees[i].Role.ToString(), employees[j].Role.ToString()) > 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        case 2:
                            if (string.Compare(employees[i].Role.ToString(), employees[j].Role.ToString()) < 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid sorting order");
                            break;
                    }
                }
            }
        }
        
        public static void SortByDepartment(List<Employee> employees,int sortingOrder)
        {
            for (int i = 0; i < employees.Count - 1; i++) {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    
                    switch (sortingOrder)
                    {
                        case 1:
                            if (string.Compare(employees[i].Department.ToString(), employees[j].Department.ToString()) > 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        case 2:
                            if (string.Compare(employees[i].Department.ToString(), employees[j].Department.ToString()) < 0)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid sorting order");
                            break;
                    }
                }
            }
        }
        
        public static void SortBySalary(List<Employee> employees,int sortingOrder)
        {
            for (int i = 0; i < employees.Count - 1; i++) {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    
                    switch (sortingOrder)
                    {
                        case 1:
                            if (employees[i].Salary > employees[j].Salary)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        case 2:
                            if (employees[i].Salary < employees[j].Salary)
                            {
                                Swap(employees,i,j);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid sorting order");
                            break;
                    }
                }
            }
        }

        private static void Swap(List<Employee> employee,int i,int j)
        {
            Employee temp = employee[i];
            employee[i] = employee[j];
            employee[j] = temp;
            
        }
    }
}