using System.Linq;
using System.Threading.Tasks;
using System;
using BarakaTexnika.Api.Employees;

namespace BarakaTexnika.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Employee> InsertEmployeeAsync(Employee employee);
        IQueryable<Employee> SelectAllEmployees();
        ValueTask<Employee> UpdateEmployeeAsync(Employee employee);
        ValueTask<Employee> SelectEmployeeByIdAsync(Guid id);
        ValueTask<Employee> DeleteEmployeeAsync(Employee employee);
    }
}
