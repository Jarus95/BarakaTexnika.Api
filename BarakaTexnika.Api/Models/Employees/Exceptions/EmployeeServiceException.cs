using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class EmployeeServiceException : Xeption
    {
        public EmployeeServiceException(Xeption innerException)
            : base("Employee service error occure. fix the error",  innerException)
        { }
    }
}
