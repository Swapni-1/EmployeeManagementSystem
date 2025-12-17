using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Utilities;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void CreateEmployee()
        {
            Employee employee = new Employee();

            //Auto generating employee id 
            employee.Id = _repository.GetAll().Count + 1;
            
            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();
            
            
            string roleChoice = "1. Employee \n2. Manager \n3. Intern";
            employee.Role = EnumHelper.GetValidatedEnumInput<Role>("role", roleChoice);

            string departmentChoice = "1. HR \n2. Finance \n3. Engineering \n4. Sales \n5. Marketing";
            employee.Department = EnumHelper.GetValidatedEnumInput<Department>("department", departmentChoice);

            /*
             This
             InputValidator.GetValidatedSalary()
             will ask for salary 
             eg. Enter salary : 
             and it will run 
             until it gets validated salary 
             */
            employee.Salary = InputValidator.GetValidatedSalary();

            _repository.Add(employee);
            Console.WriteLine("Employee created successfully");
        }

        public void UpdateEmployee()
        {
            
            Console.Write("Enter Employee ID : ");
            string id = Console.ReadLine();

            if (int.TryParse(id, out int ID))
            {
                Employee employee = _repository.GetById(ID);


                if (employee == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }

                Console.WriteLine("Update employee by : ");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Role");
                Console.WriteLine("3. Department");
                Console.WriteLine("4. Salary");
                Console.WriteLine("Enter update choice : ");
                string UpdateInput = Console.ReadLine();

                if (int.TryParse(UpdateInput, out int choice))
                {

                    switch (choice)
                    {
                        case 1:
                            employee.Name = Console.ReadLine();
                            break;
                        case 2:
                            string roleChoice = "1. Employee \n2. Manager \n3. Intern";
                            employee.Role = EnumHelper.GetValidatedEnumInput<Role>("role", roleChoice);
                            break;
                        case 3:
                            string departmentChoice = "1. HR \n2. Finance \n3. Engineering \n4. Sales \n5. Marketing";
                            employee.Department =
                                EnumHelper.GetValidatedEnumInput<Department>("department", departmentChoice);
                            break;
                        case 4:
                            employee.Salary = InputValidator.GetValidatedSalary();
                            break;
                        default:
                            Console.WriteLine("Error : Invalid update choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error : Invalid number");
                }
            }
            else
            {
                Console.WriteLine("Error : Invalid number");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee ID : ");
            string id = Console.ReadLine();

            if (int.TryParse(id, out int ID))
            {

                Employee employee = _repository.GetById(ID);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }
                
                _repository.Delete(ID);
                Console.WriteLine("Employee deleted successfully");
            }
            else
            {
                Console.WriteLine("Error : Invalid number");
            }
        }

        public void DisplayEmployeeById()
        {
            Console.Write("Enter Employee ID : ");
            string id = Console.ReadLine();

            if (int.TryParse(id, out int ID))
            {
                Employee employee = _repository.GetById(ID);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }
                Display(employee);
            }
            else
            {
                Console.WriteLine("Error : Invalid number");
            }
        }

        public void DisplayAllEmployees()
        {
             List<Employee> employees = _repository.GetAll();
             foreach (Employee employee in employees)
             {
                 Display(employee);
             }
        }

        private void Display(Employee employee)
        {
            Console.WriteLine($"ID : {employee.Id} | Name : {employee.Name} | Role : {employee.Role} | Department : {employee.Department} | Salary : {employee.Salary:C}");
        }
    }
}