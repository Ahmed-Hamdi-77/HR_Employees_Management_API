using ServicesContracts.DTOs.AttendancesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.AttendanceContracts
{
    public interface IAttendanceGetterService
    {
        /// <summary>
        /// Returns All attendance of an Employee by Employee id
        ///  /// <param name="EmployeeId">Employee id that have the attendancies,
        /// </summary>
        /// <returns>Returns a list of objects of AttendanceResponse type</returns>
        Task<List<AttendanceResponse>> GetAllAttendances(Guid EmployeeId);

        /// <summary>
        /// Retruns a Attendance by Attendance id 
        /// </summary>
        /// <returns>Rutruns a mathced Attendance with AttendanceId as a AttendanceResponse object</returns>
        Task<AttendanceResponse?> GetById(Guid id);
       
    }
}
