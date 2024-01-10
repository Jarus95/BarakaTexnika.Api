﻿using System.Collections.Generic;
using System.Collections;
using System;
using System.Threading.Tasks;
using BarakaTexnika.Api.Models.Employees;
using BarakaTexnika.Api.Models.Employees.Exceptions;
using BarakaTexnika.Api.Services.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xeptions;

namespace BarakaTexnika.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Employee>> PostEmployee(EmployeeDTO employee)
        {
            try
            {
                Employee persistedEmployee = await this.employeeService.AddEmployeeAsync(employee);
                return Ok(persistedEmployee);
            }
            catch (EmployeeValidationException employeeValidationException) 
                when(employeeValidationException.InnerException is NullEmployeeException)
            {

                return BadRequest(employeeValidationException.Message + " " + 
                        employeeValidationException.InnerException.Message);
            }
            catch(EmployeeValidationException employeeValidationException)
            {

                Xeption innerException = (Xeption)employeeValidationException.InnerException;
                string exception = innerException.Message;
                foreach (DictionaryEntry item in innerException.Data)
                {
                    string errorSummary = ((List<string>)item.Value)
                        .Select((string value) => value)
                        .Aggregate((string current, string next) => current + ", " + next);
                    exception += "\n" + item.Key + " - " + errorSummary;
                }
                return BadRequest(exception);
            }
            catch(EmployeeDependencyValidationException employeeDependencyValidationException)
            {
                return BadRequest(employeeDependencyValidationException.Message + " " +
                   employeeDependencyValidationException.InnerException.Message);
            }
            catch(EmployeeDependencyException employeeDependencyException)
            {
                return BadRequest(employeeDependencyException.Message + " " +
                        employeeDependencyException.InnerException.Message);
            }
            catch(EmployeeServiceException employeeServiceException)
            {
                return BadRequest(employeeServiceException.Message + " " +
                      employeeServiceException.InnerException.Message);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Employee>> GetAllEmployee()
        {
            try
            {
                IQueryable<Employee> employees = this.employeeService.RetrieveAllEmployees();
                return Ok(employees);
            }
            catch (EmployeeDependencyException employeeDependencyException)
            {
                return BadRequest(employeeDependencyException.Message + " " +
                    employeeDependencyException.InnerException.Message);
            }
            catch(EmployeeServiceException employeeServiceException)
            {
                return BadRequest(employeeServiceException.Message + " " +
                  employeeServiceException.InnerException.Message);
            }
        }
    }
}