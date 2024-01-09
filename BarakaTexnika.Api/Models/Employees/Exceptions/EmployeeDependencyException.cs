using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class EmployeeDependencyException : Xeption
    {
        public EmployeeDependencyException(Xeption innerException)
            : base("Employee dependency error ocured.Fix the error and try again", innerException)
        { }
    }
}
