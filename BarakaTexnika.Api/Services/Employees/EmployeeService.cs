using System;
using System.Linq;
using System.Threading.Tasks;
using BarakaTexnika.Api.Brokers.Loggings;
using BarakaTexnika.Api.Brokers.Storages;
using BarakaTexnika.Api.Models.Employees;

namespace BarakaTexnika.Api.Services.Employees
{
    public partial class EmployeeService : IEmployeeService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public EmployeeService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Employee> AddEmployeeAsync(EmployeeDTO employeeDto) =>
        TryCatch(async () =>
        {
            Employee employee = MapEmployee(employeeDto);
            ValidateEmployeeOnAdd(employee);
            return await this.storageBroker.InsertEmployeeAsync(employee);
        });

        public IQueryable<Employee> RetrieveAllEmployees() =>
        TryCatch(() =>
        {
           return this.storageBroker.SelectAllEmployees();

        });

        public ValueTask<Employee> ModifyEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Employee> RemoveEmployeeAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Employee> RetrieveEmployeeByIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        private Employee MapEmployee(EmployeeDTO employeeDto)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                JobTitle = employeeDto.JobTitle,
                Salary = employeeDto.Salary
            };

            return employee;
        }
    }
}
