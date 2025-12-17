namespace EmployeeManagementSystem.Utilities
{
    public static class SalaryValidation
    {
        public static bool CheckNegative(decimal salary)
        {
            if (salary < 0)
            {
                return true;
            }

            return false;
        }
    }
}