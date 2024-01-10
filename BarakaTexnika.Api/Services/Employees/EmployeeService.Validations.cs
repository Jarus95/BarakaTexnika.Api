using System;
using BarakaTexnika.Api.Models.Employees;
using BarakaTexnika.Api.Models.Employees.Exceptions;

namespace BarakaTexnika.Api.Services.Employees
{
    public partial class EmployeeService
    {
        private void ValidateEmployeeOnAdd(Employee employee)
        {
            ValidateEmployeeNotNull(employee);
            Validate(
             (Rule: IsInvalid(employee.Id), Parameter: nameof(employee.Id)),
             (Rule: IsInvalid(employee.Name), Parameter: nameof(employee.Name)),
             (Rule: IsInvalid(employee.Age), Parameter: nameof(employee.Age)),
             (Rule: IsInvalid(employee.Salary), Parameter: nameof(employee.Salary)),
             (Rule: IsInvalid(employee.JobTitle), Parameter: nameof(employee.JobTitle))
             );

        }
        private void ValidateEmployeeOnModify(Employee employee)
        {
            ValidateEmployeeNotNull(employee);
            Validate(
               (Rule: IsInvalid(employee.Id), Parameter: nameof(employee.Id)),
               (Rule: IsInvalid(employee.Name), Parameter: nameof(employee.Name)),
               (Rule: IsInvalid(employee.Age), Parameter: nameof(employee.Age)),
               (Rule: IsInvalid(employee.Salary), Parameter: nameof(employee.Salary)),
               (Rule: IsInvalid(employee.JobTitle), Parameter: nameof(employee.JobTitle))
               );
        }

        private void ValidateEmployeeNotFound(Employee maybeEmployee)
        {
            if(maybeEmployee is null)
            {
                throw new NotFoundEmployeeException(maybeEmployee.Id);
            }
        }


        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };
        private dynamic IsInvalid(int age) => new
        {
            Condition = age == default,
            Message = "age is required"
        };
        private dynamic IsInvalid(decimal salary) => new
        {
            Condition = salary == default,
            Message = "salary is required"
        };
        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };
        private static void ValidateEmployeeNotNull(Employee employee)
        {
            if (employee is null)
            {
                throw new NullEmployeeException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidEmployeeException = new InvalidEmployeeException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidEmployeeException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidEmployeeException.ThrowIfContainsErrors();
        }
    }
}
