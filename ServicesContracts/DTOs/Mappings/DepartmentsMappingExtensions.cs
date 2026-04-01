using Models;
using ServicesContracts.DTOs.DepartmentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.Mappings
{
    public static class DepartmentsMappingExtensions
    {
        // An extension method to convert an object of Department entity to DepartmentResponse object
        public static DepartmentResponse ToDepartmentResponse(this Department department)
            {
            //Department=>DepartmentResponse
            if (department == null) return null!;
    
                return new DepartmentResponse
                {
                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description
                };
        }

        // An extension method to convert DepartmentUpdateRequest object to Department entity
        public static Department ToDepartment(this DepartmentUpdateRequest departmentUpdateRequest)
        {
            //DepartmentUpdateRequest=>Department
            return new Department
            {
                Id= departmentUpdateRequest.Id,
                Name = departmentUpdateRequest.Name,
                Description = departmentUpdateRequest.Description
            };
        }
        // An extension method to convert DepartmentAddRequest object to Department entity  
        public static Department ToDepartment(this DepartmentAddRequest departmentAddRequest)
        {
            //DepartmentAddRequest=>Department
            return new Department
            {
                Name = departmentAddRequest.Name,
                Description = departmentAddRequest.Description
            };
        }

    }
}
