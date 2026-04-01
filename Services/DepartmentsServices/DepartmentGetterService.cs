using Models;
using Repository;
using RepositoryContracts;
using ServicesContracts.DepartmentContracts;
using ServicesContracts.DTOs.DepartmentsDTOs;
using ServicesContracts.DTOs.Mappings;

namespace Services.AttendanciesServieces
{
    public class DepartmentGetterService : IDepartmentGetterService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentGetterService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponse> GetById(Guid id)
        {
            // Check if the provided ID is null and throw an exception if it is
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Department ID is invalid.", nameof(id));
            }

            // Call the repository method to get the department by its ID
            Department? department = await _departmentRepository.GetDepartmentById(id);

            // Convert the department to an DepartmentResponse object and return it
            return department.ToDepartmentResponse();

        }

        public async Task<List<DepartmentResponse?>> GetAll()
        {
            // Call the repository method to get all departments
            List<Department> departments = await _departmentRepository.GetAllDepartments();
            // Convert the list of departments to a list of DepartmentResponse objects and return it
            return departments.Select(d => d.ToDepartmentResponse()).ToList();
        }
    }
}
