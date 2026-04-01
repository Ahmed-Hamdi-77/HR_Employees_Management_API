
using static Models.Enums.LeaveRequestOptions;

namespace Models
{
    public class LeaveRequest
    {
        public Guid id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public LeaveType Type { get; set; } 
        public LeaveStatus Status { get; set; }

        //===== FK ======
        public Guid EmployeeId { get; set; }
        public Guid? ApprovedByManagerId { get; set; }
        public Guid? ApprovedByHRId { get; set; }

        //===== Navigation =====
        public virtual Employee Employee { get; set; } = null!;
        public virtual Employee? ApprovedByManager { get; set; } = null!;
        public virtual Employee? ApprovedByHR { get; set; } = null!;
    }
}
