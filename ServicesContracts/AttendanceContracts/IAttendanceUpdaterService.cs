using ServicesContracts.DTOs.AttendancesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.AttendanceContracts
{
    public interface IAttendanceUpdaterService
    {
        /// <summary>
        /// Updates the specified Attendance details based on the given 
        /// Attendance AttendanceId 
        /// </summary>
        /// <param name="AttendanceUpdateRequest">Attendance details to update,
        /// including Attendance id </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the AttendanceUpdateRequest is empty .
        /// </exception>  
        /// <returns>Returns the Attendance response object after
        /// updation</returns>
        Task<AttendanceResponse> UpdateAttendance(AttendanceUpdateRequest AttendanceUpdateRequest);
    }
}
