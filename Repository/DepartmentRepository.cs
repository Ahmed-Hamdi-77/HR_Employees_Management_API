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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly API_DbContext _DbContext;

        public DepartmentRepository(API_DbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            await _DbContext.Departments.AddAsync(department);
            await _DbContext.SaveChangesAsync();
            return department;
        }

        public async Task DeleteDepartment(Guid departmentId)
        {
            var department = await _DbContext.Departments.FirstOrDefaultAsync(d => d.Id == departmentId) ?? throw new KeyNotFoundException($"Department with ID {departmentId} not found.");

            _DbContext.Departments.Remove(department);
           
             await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _DbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(Guid departmentId)
        {
            var department= await _DbContext.Departments.FirstOrDefaultAsync(d => d.Id == departmentId) ?? throw new KeyNotFoundException("Department is not found");
            return department;

        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var matchedDepartment= await _DbContext.Departments.FirstOrDefaultAsync(d=> d.Id == department.Id)?? throw new KeyNotFoundException("Department is not found"); 

            matchedDepartment.Name = department.Name;
            matchedDepartment.Description = department.Description;            

            await _DbContext.SaveChangesAsync();

            return matchedDepartment;
        }
    }
}
