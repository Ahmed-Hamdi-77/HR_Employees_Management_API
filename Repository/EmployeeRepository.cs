using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly API_DbContext _context;

        public EmployeeRepository(API_DbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;

        }

        public async Task DeleteEmployee(Guid employeeId)
        {
           var matchedEmployee= await _context.Employees.FirstOrDefaultAsync(e=>e.Id==employeeId) ?? throw new KeyNotFoundException($"Employee with ID {employeeId} not found."); ;
            
             _context.Employees.Remove(matchedEmployee);
             await _context.SaveChangesAsync();            
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(Guid employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var matchedEmployee =await _context.Employees.FirstOrDefaultAsync(e => e.Id == updatedEmployee.Id) ?? throw new KeyNotFoundException($"Employee not found."); ;
            

            matchedEmployee.FullName = updatedEmployee.FullName;
            matchedEmployee.Email = updatedEmployee.Email;
            matchedEmployee.DepartmentId = updatedEmployee.DepartmentId;
            matchedEmployee.ManagerId = updatedEmployee.ManagerId;
            matchedEmployee.HireDate = updatedEmployee.HireDate;
            matchedEmployee.IsActive = updatedEmployee.IsActive;
            matchedEmployee.Phone= updatedEmployee.Phone;
            matchedEmployee.Salary = updatedEmployee.Salary;
            await _context.SaveChangesAsync();
            
            return matchedEmployee;
        }
    }
}
