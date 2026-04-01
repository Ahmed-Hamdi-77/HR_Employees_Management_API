using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.LeavesDTOs
{
    //Acts as a DTO for adding a new leave request
    public class LeaveAddRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }       
        public Guid EmployeeId { get; set; }
        public Guid ApprovedByManagerId { get; set; }
        public Guid ApprovedByHRId { get; set; }
    }
}
