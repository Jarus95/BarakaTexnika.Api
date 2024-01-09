using System;
using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class EmployeeValidationException : Xeption
    {
        public EmployeeValidationException(Xeption innerException)
            : base("Employee validation error occured fix the error and try again", innerException)
        { }
    }
}
