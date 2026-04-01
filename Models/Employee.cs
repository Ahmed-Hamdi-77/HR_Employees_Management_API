namespace Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }

        //======= FK =======
        public Guid DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }

        //====== Navigation ======
        public  Department Department { get; set; } = null!;
        public  Employee? Manager { get; set; }

        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<LeaveRequest> ApprovedManagerLeaves { get; set; }= new List<LeaveRequest>();
        public ICollection<LeaveRequest> ApprovedHRLeaves { get; set; } = new List<LeaveRequest>();



    }
}
