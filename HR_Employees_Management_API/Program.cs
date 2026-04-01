
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Identity;
using Repository;
using RepositoryContracts;
using Services.AttendanciesServieces;
using ServicesContracts.AttendanceContracts;
using ServicesContracts.DepartmentContracts;
using ServicesContracts.EmployeeContracts;
using ServicesContracts.LeaveContracts;

namespace HR_Employees_Management_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Registering the services in the container

            //Attendance services
            builder.Services.AddScoped<IAttendanceAdderService, AttendanceAdderService>();
            builder.Services.AddScoped<IAttendanceGetterService, AttendanceGetterService>();
            builder.Services.AddScoped<IAttendanceUpdaterService, AttendanceUpdaterService>();
            builder.Services.AddScoped<IAttendanceDeleterService, AttendanceDeleterService>();

            //Department services
            builder.Services.AddScoped<IDepartmentAdderService, DepartmentAdderService>();
            builder.Services.AddScoped<IDepartmentGetterService, DepartmentGetterService>();
            builder.Services.AddScoped<IDepartmentUpdaterService, DepartmentUpdaterService>();
            builder.Services.AddScoped<IDepartmentDeleterService, DepartmentDeleterService>();

            //Employee services
            builder.Services.AddScoped<IEmployeeAdderService, EmployeeAdderService>();
            builder.Services.AddScoped<IEmployeeGetterService, EmployeeGetterService>();
            builder.Services.AddScoped<IEmployeeUpdaterService, EmployeeUpdaterService>();
            builder.Services.AddScoped<IEmployeeDeleterService, EmployeeDeleterService>();

            //Leave services
            builder.Services.AddScoped<ILeaveAdderService, LeaveAdderService>();
            builder.Services.AddScoped<ILeaveGetterService, LeaveGetterService>();
            builder.Services.AddScoped<ILeaveUpdaterService, LeaveUpdaterService>();

            // Repositories
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            //Adding the DbContext as a service
            builder.Services.AddDbContext<API_DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"))
            );

            //Enable identity framework service
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<API_DbContext>()
                .AddDefaultTokenProviders().AddRoleStore<RoleStore<ApplicationRole, API_DbContext, Guid>>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, API_DbContext, Guid>>();

            //If you want specific origin you can add it here instead of AllowAnyOrigin
            builder.Services.AddCors(options=>
            options.AddPolicy("MyPolicy",builder=>
            builder.AllowAnyOrigin()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
