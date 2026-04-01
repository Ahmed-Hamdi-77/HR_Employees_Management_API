using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public class LeaveRequestOptions
    {
        public enum LeaveType
        {
            Annual,Sick,Emergency
        }

        public enum LeaveStatus
        {
            Pending,ApprovedByManager,
            ApprovedByHR,Rejected
            
        }
    }
}
