using Repository;
using RepositoryContracts;
using ServicesContracts.DepartmentContracts;
using ServicesContracts.DTOs.DepartmentsDTOs;
using ServicesContracts.DTOs.Mappings;

namespace Services.AttendanciesServieces
{
    public class DepartmentUpdaterService : IDepartmentUpdaterService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentUpdaterService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponse> UpdateDepartment(DepartmentUpdateRequest departmentUpdateRequest)
        {
            //Check if departmentUpdateRequest is null
            if (departmentUpdateRequest is null)
                throw new ArgumentNullException("Department update request cannot be null.", nameof(departmentUpdateRequest));

            //Mapping
            var department= departmentUpdateRequest.ToDepartment();

            //Update the object
             var UpdatedDepartment= await _departmentRepository.UpdateDepartment(department);
            
            //Return updated object as department response
            return UpdatedDepartment.ToDepartmentResponse();
        }
    }
}
