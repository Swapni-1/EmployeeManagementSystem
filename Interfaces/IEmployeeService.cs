using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeService
    {
        void CreateEmployee();
        void UpdateEmployee();
        void DeleteEmployee();
        void DisplayEmployeeById();
        void DisplayAllEmployees();
    }
}