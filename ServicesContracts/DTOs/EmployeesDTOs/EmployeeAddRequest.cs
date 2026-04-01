using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.EmployeesDTOs
{
    //Acts as a DTO for inserting a new person
    public class EmployeeAddRequest
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Phone { get; set; } = null!;
        public DateTime HireDate { get; set; }

        public Guid DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
