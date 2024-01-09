using System;
using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class FailedEmployeeServiceException : Xeption
    {
        public FailedEmployeeServiceException(Exception innerException)
            : base("Failed employee service error occured,fix the error", innerException)
        { }
    }
}
