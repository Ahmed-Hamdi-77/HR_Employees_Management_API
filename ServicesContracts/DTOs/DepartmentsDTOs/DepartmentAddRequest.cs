using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.DepartmentsDTOs
{
    //Acts as a DTO for inserting a new Department
    public class DepartmentAddRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 

    }
}
