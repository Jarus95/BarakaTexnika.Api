using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class NullEmployeeException : Xeption
    {
        public NullEmployeeException()
         :base("Employee is null")
        { }
    }
}
