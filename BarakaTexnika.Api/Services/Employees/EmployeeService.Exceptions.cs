using System;
using System.Linq;
using System.Threading.Tasks;
using BarakaTexnika.Api.Models.Employees;
using BarakaTexnika.Api.Models.Employees.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace BarakaTexnika.Api.Services.Employees
{
    public partial class EmployeeService
    {
        private delegate ValueTask<Employee> ReturningEmployeeFunction();
        private delegate IQueryable<Employee> ReturningEmployeesFunction();

        private IQueryable<Employee> TryCatch(ReturningEmployeesFunction returningEmployeesFunction)
        {
            try
            {
                return returningEmployeesFunction();
            }
            catch (SqlException sqlException)
            {
                var failedEmployeeStorageException =
                    new FailedEmployeeStorageException(sqlException);
                throw CreateAndLogCriticalDependencyException(failedEmployeeStorageException);
            }
            catch (Exception exception)
            {
                var failedEmployeeServiceException =
                    new FailedEmployeeServiceException(exception);
                throw CreateAndLogServiceException(failedEmployeeServiceException);
            }
        }

        private async ValueTask<Employee> TryCatch(ReturningEmployeeFunction returningEmployeeFunction)
        {
            try
            {
                return await returningEmployeeFunction();
            }
            catch (NullEmployeeException nullEmployeeException)
            {
                throw CreateAndLogValidationException(nullEmployeeException);
            }
            catch (InvalidEmployeeException invalidEmployeeException)
            {
                throw CreateAndLogValidationException(invalidEmployeeException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var employeeAlreadyExistsException = 
                    new EmployeeAlreadyExistsException(duplicateKeyException);

                throw CreateAndALogDependencyValidationException(employeeAlreadyExistsException);
            }
            catch(SqlException sqlException)
            {
                var failedEmployeeStorageException = 
                    new FailedEmployeeStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedEmployeeStorageException);
            }
            catch(NotFoundEmployeeException notFoundEmployeeException)
            {
                throw CreateAndLogValidationException(notFoundEmployeeException);
            }
            catch (Exception exception) 
            {
                var failedEmployeeServiceException =
                    new FailedEmployeeServiceException(exception);

                throw CreateAndLogServiceException(failedEmployeeServiceException);
            }
        }

        private EmployeeServiceException CreateAndLogServiceException(Xeption innerException)
        {
            EmployeeServiceException employeeServiceException =
                new EmployeeServiceException(innerException);

            this.loggingBroker.LogError(employeeServiceException);

            return employeeServiceException;
        }

        private EmployeeDependencyException CreateAndLogCriticalDependencyException(Xeption innerException)
        {
            var employeeDependencyException = 
                new EmployeeDependencyException(innerException);

            this.loggingBroker.LogCritical(employeeDependencyException);
            
            return employeeDependencyException;
        }

        private EmployeeDependencyValidationException CreateAndALogDependencyValidationException(Xeption innerException)
        {
            var employeeDependencyValidationException = new EmployeeDependencyValidationException(innerException);

            this.loggingBroker.LogError(employeeDependencyValidationException);

            return employeeDependencyValidationException;
        }

        private EmployeeValidationException CreateAndLogValidationException(Xeption innerException)
        {
            var employeeValidationException = new EmployeeValidationException(innerException);

            this.loggingBroker.LogError(employeeValidationException);

            return employeeValidationException;
        }
    }
}
