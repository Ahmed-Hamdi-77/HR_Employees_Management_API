using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.AttendancesDTOs
{
    //Acts as a DTO for adding a new Department
    public class AttendanceAddRequest
    {
        public DateTime Date { get; set; } 
        public TimeSpan? CheckInTime { get; set; } 
        public TimeSpan? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; } 

        public Guid EmployeeId { get; set; }
    }
}
