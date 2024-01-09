using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using BarakaTexnika.Api.Models.Employees;

namespace BarakaTexnika.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Employee> Employee { get; set; }

        public async ValueTask<Employee> InsertEmployeeAsync(Employee employee) =>
            await InsertAsync(employee);

        public IQueryable<Employee> SelectAllEmployees() =>
            SelectAll<Employee>();

        public async ValueTask<Employee> UpdateEmployeeAsync(Employee employee) =>
           await UpdateEmployeeAsync(employee);

        public async ValueTask<Employee> SelectEmployeeByIdAsync(Guid id) =>
            await SelectEmployeeByIdAsync(id);

        public async ValueTask<Employee> DeleteEmployeeAsync(Employee employee) =>
            await DeleteEmployeeAsync(employee);
    }
}
