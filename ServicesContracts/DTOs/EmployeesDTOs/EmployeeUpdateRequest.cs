using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.EmployeesDTOs
{
    //Acts as a DTO for updating an exisiting employee
    public class EmployeeUpdateRequest
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string?   Email { get; set; }
        public decimal? Salary { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }

        public Guid DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
