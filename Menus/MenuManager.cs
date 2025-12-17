using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Utilities;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Menus
{
    public class MenuManager
    {
        private IEmployeeService _service;
        private IEmployeeRepository _repository;

        public MenuManager(IEmployeeService service,IEmployeeRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public void Handle(int choice)
        {
            switch (choice)
            {
                case 1:
                    _service.CreateEmployee();
                    break;
                case 2:
                    _service.UpdateEmployee();
                    break;
                case 3:
                    _service.DeleteEmployee();
                    break;
                case 4:
                    _service.DisplayEmployeeById();
                    break;
                case 5:
                    _service.DisplayAllEmployees();
                    break;
                case 6:
                    SortMenu();
                    break;
                case 7:
                    FilterMenu();
                    break;
                case 8:
                    GroupMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private void SortMenu()
        {
            List<Employee> employees = _repository.GetAll();
            Aggregates aggregates = null;
            
            Console.WriteLine("Sort Order By : ");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            Console.Write("Choice : ");
            string sortOrderOption = Console.ReadLine();
            
            if (int.TryParse(sortOrderOption, out int sortOrderChoice))
            {
                if (sortOrderChoice >= 1 && sortOrderChoice <= 2)
                {
                    string sortChoices = "Sort By : \n1. ID \n2. Name \n3. Role \n4. Department \n5. Salary \nchoice : ";
                    Console.Write(sortChoices);
                    string sortOption = Console.ReadLine();
                    
                    if (int.TryParse(sortOption, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                EmployeeSorter.SortById(employees,sortOrderChoice);
                                break;
                            case 2:
                                EmployeeSorter.SortByName(employees,sortOrderChoice);
                                break;
                            case 3:
                                EmployeeSorter.SortByRole(employees,sortOrderChoice);
                                break;
                            case 4:
                                EmployeeSorter.SortByDepartment(employees,sortOrderChoice);
                                break;
                            case 5:
                                EmployeeSorter.SortBySalary(employees,sortOrderChoice);
                                break;
                            default:
                                Console.WriteLine("Invalid sort option");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error : invalid number");
                    }

                }
                else
                {
                    Console.WriteLine("Error : invalid sort by option");
                }      
            }
            else
            {
                Console.WriteLine("Error : invalid number");
            }

            Display(employees,aggregates);

        }

        private void FilterMenu()
        {
            List<Employee> employees = _repository.GetAll();
            List<Employee> result = null;
            Aggregates aggregates = null;
            
            string filterChoices = "Filter By : \n1. ID \n2. Name \n3. Role \n4. Department \n5. Salary \nchoice : ";
            Console.Write(filterChoices);
            string filterOption = Console.ReadLine();

            if (int.TryParse(filterOption, out int filterChoice))
            {
                switch (filterChoice)
                {
                     case 1:
                         Console.Write("Enter ID : ");
                         if (int.TryParse(Console.ReadLine(), out int id))
                         {
                            result = EmployeeFilter.FilterById(employees,id);
                         }
                         else
                         {
                             Console.WriteLine("Error : invalid ID");
                         }

                         break;
                     case 2:
                         Console.Write("Enter Name : ");
                         result = EmployeeFilter.FilterByName(employees,Console.ReadLine());
                         break;
                     case 3:
                         string roleChoice = "1. Employee \n2. Manager \n3. Intern";
                         Role role = EnumHelper.GetValidatedEnumInput<Role>("role", roleChoice);
                         result = EmployeeFilter.FilterByRole(employees,role);
                         break;
                     case 4:
                         string departmentChoice = "1. HR \n2. Finance \n3. Engineering \n4. Sales \n5. Marketing";
                         Department department = EnumHelper.GetValidatedEnumInput<Department>("department", departmentChoice);
                         result = EmployeeFilter.FilterByDepartment(employees,department);
                         break;
                     case 5:
                         Console.WriteLine("Enter salary range : ");
                         
                         Console.Write("Minimum range: ");
                         decimal minSalary = InputValidator.GetValidatedSalary();
                         
                         Console.Write("Maximum range: ");
                         decimal maxSalary = InputValidator.GetValidatedSalary();
                         
                         result = EmployeeFilter.FilterBySalary(employees,minSalary,maxSalary);
                         break;
                     default:
                         Console.WriteLine("Error : invalid filter option");
                         break;
                }
            }
            else
            {
                Console.WriteLine("Error : invalid number");
            }
            Display(result,aggregates);
        }

        private void GroupMenu()
        {
            List<Employee> employees = _repository.GetAll();
            Dictionary<string, List<Employee>> result = null;
            Aggregates aggregates = null;
            
            Console.WriteLine("Group By : ");
            Console.WriteLine("1. Role");
            Console.WriteLine("2. Department");
            Console.Write("Choice : ");
            string groupOption = Console.ReadLine();
            
            
            if (int.TryParse(groupOption, out int groupChoice))
            {
                switch (groupChoice)
                {
                    case 1:
                        result = EmployeeGrouper.GroupByRole(employees);     
                        break;
                    case 2:
                        result = EmployeeGrouper.GroupByDepartment(employees);
                        break;
                    default:
                        Console.WriteLine("Error : invalid group by option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error : invalid number");
            }

            foreach (var key in result.Keys)
            {
                Console.WriteLine($"Group : {key}");
                aggregates = Calculate.Aggregates(result[key]);
                Display(result[key],aggregates);
            }

        }

        private void Display(List<Employee> employees,Aggregates aggregates)
        {
            if (aggregates != null)
            {
                Console.WriteLine($"Employee Count : {aggregates.EmployeeCount}");
                Console.WriteLine($"Total Salary : {aggregates.SumOfSalaries:C}");
                Console.WriteLine($"Average Salary : {aggregates.AverageSalary:C}");
                Console.WriteLine($"Minimum Salary : {aggregates.MinimumSalary:C}");
                Console.WriteLine($"Minimum Salary : {aggregates.MaximumSalary:C}");
            }

            foreach (Employee employee in employees)    
            {
               Console.WriteLine($"ID : {employee.Id} | Name : {employee.Name} | Role : {employee.Role} | Department : {employee.Department} | Salary : {employee.Salary:C}");
            }

        }
        
    }
}