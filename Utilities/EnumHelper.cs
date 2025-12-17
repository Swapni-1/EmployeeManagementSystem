namespace EmployeeManagementSystem.Utilities
{
    public static class EnumHelper
    {
        public static TEnum GetValidatedEnumInput<TEnum>(string prompt,string choices)
        where TEnum : struct,Enum 
        /* struct - it will define that TEnum will not nullable and it will value type,
         Enum - it will define that that TEnum will be Enum type*/
        {
            while (true)
            {
                Console.WriteLine($"Enter {prompt} : ");
                Console.WriteLine(choices);
                Console.Write($"{prompt} choice (Enter number): ");
                string input = Console.ReadLine();
            
                /*It must be convertible (a valid number or a valid string name).
                It must be a defined member of the target enum (preventing invalid numeric values).*/
                
                if (Enum.TryParse<TEnum>(input, true, out TEnum result))
                    //This will convert input eg. 2 or manager and true means ignorecase, to enum type eg. Role.Manager
                {
                    if (Enum.IsDefined(typeof(TEnum), result))
                        //This will ensure that it is defined in Role Enum eg. enum Role{Employee=2,Manager=2,Intern=3}
                    {
                        return result;
                    }
                }
                
                Console.WriteLine($"Error : Invalid {prompt} choice and Enter valid input number");
                
            }
        }
    }
}