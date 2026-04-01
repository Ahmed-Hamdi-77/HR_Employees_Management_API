using Models;
using ServicesContracts.DTOs.AttendancesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.Mappings
{
    public static class AttendanceMappingExtensions
    {
        // An extension method to convert an object of Attendance entity to AttendanceResponse object
        public static AttendanceResponse ToAttendanceResponse(this Attendance attendance)
        {
            //Attendance=>AttendanceResponse
            return new AttendanceResponse
            {
                Id = attendance.Id,
                Date = attendance.Date,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
                Status = attendance.Status,
                EmployeeId = attendance.EmployeeId
            };
        }

        // An extension method to convert AttendanceUpdateRequest object to Attendance entity
        public static Attendance ToAttendance(this AttendanceUpdateRequest attendanceUpdateRequest)
        {
            //AttendanceUpdateRequest=>Attendance
            return new Attendance
            {
                Id = attendanceUpdateRequest.Id,
                Date = attendanceUpdateRequest.Date,
                CheckInTime = attendanceUpdateRequest.CheckInTime,
                CheckOutTime = attendanceUpdateRequest.CheckOutTime,
                Status = attendanceUpdateRequest.Status,
                EmployeeId = attendanceUpdateRequest.EmployeeId
            };
        }

        // An extension method to convert AttendanceAddRequest object to Attendance entity
        public static Attendance ToAttendance(this AttendanceAddRequest attendanceAddRequest)
        {
            //AttendanceAddRequest=>Attendance
            return new Attendance
            {
                Date = attendanceAddRequest.Date,
                CheckInTime = attendanceAddRequest.CheckInTime,
                CheckOutTime = attendanceAddRequest.CheckOutTime,
                Status = attendanceAddRequest.Status,
                EmployeeId = attendanceAddRequest.EmployeeId
            };
        }
    }
}
