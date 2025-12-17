namespace EmployeeManagementSystem.Utilities
{
    public static class InputValidator
    {
        public static decimal GetValidatedSalary(decimal minSalary = 0)
        {
            while (true)
            {
                Console.Write("Enter Salary : ");
                string salary = Console.ReadLine();
                
                if (decimal.TryParse(salary, out decimal result) && result > minSalary)
                {
                    return result;
                }
                
                Console.WriteLine($"Error : Please enter valid salary and salary must greater than {minSalary}");

            }
        }
    }
}