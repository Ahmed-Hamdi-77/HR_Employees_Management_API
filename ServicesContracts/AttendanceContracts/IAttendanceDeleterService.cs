using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.AttendanceContracts
{
    public interface IAttendanceDeleterService
    {
        /// <summary>
        /// Deletes the Attendance with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the attendance to delete. If <see langword="null"/>, the operation will not delete any
        /// attendance.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the Attendance with the specified ID does not exist.
        /// </exception>   

        Task DeleteAttendance(Guid id);
    }
}
