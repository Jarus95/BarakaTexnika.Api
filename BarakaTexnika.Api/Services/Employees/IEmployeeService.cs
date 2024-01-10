using System.Linq;
using System.Threading.Tasks;
using System;
using BarakaTexnika.Api.Models.Employees;

namespace BarakaTexnika.Api.Services.Employees
{
    public interface IEmployeeService
    {
        ValueTask<Employee> AddEmployeeAsync(Employee employee);
        ValueTask<Employee> RetrieveEmployeeByIdAsync(Guid employeeId);
        IQueryable<Employee> RetrieveAllEmployees();
        ValueTask<Employee> ModifyEmployeeAsync(Employee employee);
        ValueTask<Employee> RemoveEmployeeAsync(Guid employeeId);
    }
}
