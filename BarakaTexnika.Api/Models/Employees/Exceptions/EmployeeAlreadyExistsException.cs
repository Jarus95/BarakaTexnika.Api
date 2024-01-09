using System;
using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class EmployeeAlreadyExistsException : Xeption
    {
        public EmployeeAlreadyExistsException(Exception innerException)
            : base("Employee is already exists", innerException)
        { }
    }
}
