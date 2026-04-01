using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Identity;

namespace Data
{
    public class API_DbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public API_DbContext(DbContextOptions<API_DbContext> options)
    : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                .IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email)
                .IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Email)
                .IsUnique();

                //Relationship with Department
                entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

                //Self reference (Manager)
                entity.HasOne(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                new Employee
                {
                    Id = Guid.Parse("2ED2F051-0160-437F-8CBA-B27B73A9848F"),
                    FullName = "Ahmed Manager",
                    Email = "manager@company.com",
                    Phone ="01149020187",
                    DepartmentId = Guid.Parse("7CFDFA2F-F4A5-4E2D-9005-4554658C00CA"),
                    ManagerId = null
                },
                new Employee
                {
                    Id = Guid.Parse("C2F5C259-F415-488B-8075-1F94246A3373"),
                    FullName = "Ali Employee",
                    Email = "employee@company.com",
                    Phone = "01254520144",
                    DepartmentId = Guid.Parse("7CFDFA2F-F4A5-4E2D-9005-4554658C00CA"),
                    ManagerId = Guid.Parse("2ED2F051-0160-437F-8CBA-B27B73A9848F")
                });
            }
            );

            builder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                .IsRequired().HasMaxLength(100);
                entity.HasIndex(d=>d.Name)
                .IsUnique();

                entity.HasData(
                    new Department
                    {
                        Id = Guid.Parse("7CFDFA2F-F4A5-4E2D-9005-4554658C00CA"),
                        Name = "IT",
                        Description = "Information Technology"
                    },
                    new Department
                    {
                        Id = Guid.Parse("97D443CC-535C-4E5A-B320-7467728BCBBC"),
                        Name = "HR",
                        Description = "Human Resources"
                    });
            }
            );

            builder.Entity<Attendance>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.CheckInTime)
                .IsRequired();

                entity.HasOne(a=>a.Employee)
                .WithMany(e=>e.Attendances)
                .HasForeignKey(e=>e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.EmployeeId, a.Date })
                .IsUnique();
            }               
            );

            builder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(l => l.id);

                entity.Property(l=>l.FromDate)
                .IsRequired();
                entity.Property(l=>l.ToDate)
                .IsRequired();
                entity.Property(l => l.Type)
                .IsRequired();
                entity.Property(l => l.Status)
                .IsRequired();

                //Employee that need the leave request
                entity.HasOne(l => l.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                //Manager that'll decide 
                entity.HasOne(l => l.ApprovedByManager)
                .WithMany(e => e.ApprovedManagerLeaves)
                .HasForeignKey(l => l.ApprovedByManagerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.ApprovedByHR)
                .WithMany(e=>e.ApprovedHRLeaves)
                .HasForeignKey(l => l.ApprovedByHRId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
        }
    }
}
