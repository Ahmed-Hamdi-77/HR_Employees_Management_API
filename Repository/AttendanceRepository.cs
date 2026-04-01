using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryContracts;

namespace Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly API_DbContext _DbContext;

        public AttendanceRepository(API_DbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task DeleteAttendance(Guid attendanceId)
        {
            var attendance= await _DbContext.Attendances.FirstOrDefaultAsync(a=>a.Id==attendanceId) ?? throw new KeyNotFoundException("Attendance not found");

            _DbContext.Attendances.Remove(attendance);
             await _DbContext.SaveChangesAsync();            
        }

        public async Task<Attendance?> GetAttendance(Guid attendanceId)
        {
            return await _DbContext.Attendances.FirstOrDefaultAsync(a => a.Id == attendanceId);
        }

        public async Task<List<Attendance>> GetAttendanciesByEmployeeId(Guid employeeId)
        {

            return await _DbContext.Attendances
         .Where(a => a.EmployeeId == employeeId)
         .ToListAsync();
        }

        public async Task<Attendance> SaveAttendance(Attendance attendance)
        {
            await _DbContext.Attendances.AddAsync(attendance);
            await _DbContext.SaveChangesAsync();
            return attendance;

        }

        public async Task<Attendance> UpdateAttendance(Attendance attendance)
        {
            var matchedAttendance = await _DbContext.Attendances.FirstOrDefaultAsync(a => a.Id == attendance.Id) ?? throw new KeyNotFoundException("Attendance not found");

            matchedAttendance.EmployeeId = attendance.EmployeeId;           
            matchedAttendance.CheckInTime=attendance.CheckInTime;
            matchedAttendance.CheckOutTime=attendance.CheckOutTime;
            matchedAttendance.Date=attendance.Date;
            await _DbContext.SaveChangesAsync();

            return matchedAttendance;
            
        }
    }
}
