using ServicesContracts.DTOs.AttendancesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicesContracts.AttendanceContracts
{
    public interface IAttendanceAdderService
    {
        /// <summary>
        /// Add the Attendance object to the list of the Attendances
        /// </summary>
        /// <param name="attendanceAddRequest"></param>
        /// <returns>/// Returns the created attendance
        /// details including the generated AttendanceId.</returns>

        Task<AttendanceResponse> AddAttendance(AttendanceAddRequest attendanceAddRequest);
    }
}
