using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.EmployeesDTOs
{
    /// <summary>
    /// DTO That is used as return for the most of the employee Service methods
    /// </summary>
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string DepartmentName { get; set; } = null!;
        public string? ManagerName { get; set; }

        public bool IsActive { get; set; }
    }
}
