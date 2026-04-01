using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.LeavesDTOs
{
    //Acts as a DTO for updating an existing leave request
    public class LeaveUpdateRequest
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
                      
    }
}
