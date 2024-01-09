using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class EmployeeDependencyValidationException : Xeption
    {
        public EmployeeDependencyValidationException(Xeption innerException)
            : base("Employee dependency error occured. Fix the error and try again", innerException)
        { }
    }
}
