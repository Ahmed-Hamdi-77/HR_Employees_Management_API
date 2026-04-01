using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.LeavesDTOs
{
    /// <summary>
    /// DTO That is used as return for the most of the LeaveRequest Service methods
    /// </summary>
    public class LeaveResponse
    {
        public Guid id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public LeaveRequestOptions.LeaveType Type { get; set; }
        public LeaveRequestOptions.LeaveStatus Status { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
