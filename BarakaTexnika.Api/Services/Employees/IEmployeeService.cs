using System.Linq;
using System.Threading.Tasks;
using System;
using BarakaTexnika.Api.Models.Employees;

namespace BarakaTexnika.Api.Services.Employees
{
    public interface IEmployeeService
    {
        ValueTask<Employee> AddUserAsync(Employee employee);
        ValueTask<Employee> RetrieveUserByIdAsync(Guid employeeId);
        IQueryable<Employee> RetrieveAllUsers();
        ValueTask<Employee> ModifyUserAsync(Employee employee);
        ValueTask<Employee> RemoveUserAsync(Guid employeeId);
    }
}
