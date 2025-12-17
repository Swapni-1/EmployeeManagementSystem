using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Get Employee By ID");
                Console.WriteLine("5. List All Employees");
                Console.WriteLine("6. Sort Employees");
                Console.WriteLine("7. Filter Employees");
                Console.WriteLine("8. Group Employees");
                Console.WriteLine("9. Exit");

                Console.WriteLine("Choose Option : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 9)
                {
                    break;
                }
            }
        }
    }
}