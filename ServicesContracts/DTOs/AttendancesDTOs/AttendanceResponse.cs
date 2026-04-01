using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.AttendancesDTOs
{
    /// <summary>
    /// DTO That is used as return for the most of the Attendance Service methods
    /// </summary>
    public class AttendanceResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; } 

        public Guid EmployeeId { get; set; }
    }
}
