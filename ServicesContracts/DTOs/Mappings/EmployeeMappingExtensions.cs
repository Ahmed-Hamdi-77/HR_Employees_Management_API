using Models;
using ServicesContracts.DTOs.EmployeesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesContracts.DTOs.Mappings
{
    public static class EmployeeMappingExtensions
    {
        // An extension method to convert an object of Employee entity to EmployeeResponse object
        public static EmployeeResponse ToEmployeeResponse(this Employee employee)
        {
            //Employee=>EmployeeResponse
            return new EmployeeResponse
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                DepartmentName = employee.Department.Name,
                ManagerName = employee.Manager.FullName,
                IsActive = employee.IsActive
            };
        }
        // An extension method to convert EmployeeUpdateRequest object to Employee entity
        public static Employee ToEmployee(this EmployeeUpdateRequest employeeUpdateRequest)
        {
            //EmployeeUpdateRequest=>Employee
            return new Employee
            {
                    Id = employeeUpdateRequest.Id,
                FullName = employeeUpdateRequest.FullName,
                Email = employeeUpdateRequest.Email,
                Salary = employeeUpdateRequest.Salary,
                Phone = employeeUpdateRequest.Phone,
                IsActive = employeeUpdateRequest.IsActive,
                DepartmentId = employeeUpdateRequest.DepartmentId,
                ManagerId = employeeUpdateRequest.ManagerId
            };
        }
        // An extension method to convert EmployeeAddRequest object to Employee entity
        public static Employee ToEmployee(this EmployeeAddRequest employeeAddRequest)
        {
            //EmployeeAddRequest=>Employee
            return new Employee
            {
                FullName = employeeAddRequest.FullName,
                Email = employeeAddRequest.Email,
                Salary = employeeAddRequest.Salary,
                Phone = employeeAddRequest.Phone,
                HireDate = employeeAddRequest.HireDate,
                DepartmentId = employeeAddRequest.DepartmentId,
                ManagerId = employeeAddRequest.ManagerId
            };

        }
        
    }
}
