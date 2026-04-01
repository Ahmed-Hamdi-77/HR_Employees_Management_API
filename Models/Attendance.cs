using Models.Enums;

namespace Models
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }

        // === FK ====
        public Guid EmployeeId { get; set; }

        // === Navigation ===
        public Employee Employee { get; set; } = null!;

        //==== Computed ==== will not be stored in DB

        public double WorkedHours => CheckOutTime.HasValue ?
            (CheckOutTime.Value - CheckInTime.Value).TotalHours : 0;

    }
}
