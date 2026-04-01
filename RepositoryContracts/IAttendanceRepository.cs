using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Attendance entity
    /// </summary>
    public interface IAttendanceRepository
    {
        /// <summary>
        /// Saves an Attendance object to the data store
        /// </summary>
        /// <param name="attendance">Attendance object to save</param>
        /// <returns>Returns the Attendance object after adding it 
        /// the table</returns>
        Task<Attendance> SaveAttendance(Attendance attendance);
        /// <summary>
        /// Deletes an Attendance object based on the attendance id 
        /// </summary>
        /// <param name="attendanceId">Attendance Id (guid) to search</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the attendance with the specified ID does not exist.
        /// </exception>        
        Task DeleteAttendance(Guid attendanceId);
        /// <summary>
        /// Returns a list of employee attendances based on the given employee id
        /// </summary>
        /// <param name="employeeId">EmployeeId (guid) to search</param>
        /// <returns>A list of attendance records for the specified employee.</returns>
        Task<List<Attendance>> GetAttendanciesByEmployeeId(Guid employeeId);
        /// <summary>
        /// Returns an attendance object based on the given attendance id         
        /// </summary>
        /// <param name="attendanceId"></param>
        /// <returns>
        /// The attendance if found; otherwise, null.
        /// </returns>
        Task<Attendance?> GetAttendance(Guid attendanceId);
        /// <summary>
        /// Updates an attendance object (attendance name and other details)        
        /// </summary>
        /// <param name="attendance">Attendance object to update</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the attendance with the specified ID does not exist.
        /// </exception>
        /// /// <returns>
        /// Updated attendance
        /// </returns>
        Task<Attendance> UpdateAttendance(Attendance attendance);
        
    }
}
