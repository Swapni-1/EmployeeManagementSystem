using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Menus;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repository = new EmployeeRepository();
            IEmployeeService service = new EmployeeService(repository);
            
            MenuManager menu = new MenuManager(service,repository);
            
            while (true)
            {
                Console.WriteLine("--- Employee Management System ---");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Get Employee By ID");
                Console.WriteLine("5. List All Employees");
                Console.WriteLine("6. Sort Employees");
                Console.WriteLine("7. Filter Employees");
                Console.WriteLine("8. Group Employees");
                Console.WriteLine("9. Exit");

                Console.Write("Choose Option : ");
                string option = Console.ReadLine();
                if (int.TryParse(option, out int choice))
                {
                   if (choice == 9)
                   {
                       break;
                   }
                   
                   menu.Handle(choice);
                }
                else
                {
                    Console.WriteLine("Error : Invalid number");
                }
            }
        }
    }
}