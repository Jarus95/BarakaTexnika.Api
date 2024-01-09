using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class InvalidEmployeeException : Xeption
    {
        public InvalidEmployeeException()
            : base("Employee is invalid")
        { }
    }
}
