using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.DepartmentsDTOs
{
    /// <summary>
    /// DTO That is used as return for the most of the department Service methods
    /// </summary>
    public class DepartmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=null!;
        public string? Description { get; set; }
    }
}
