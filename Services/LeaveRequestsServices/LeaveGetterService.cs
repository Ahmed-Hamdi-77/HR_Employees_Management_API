using Models;
using RepositoryContracts;
using ServicesContracts.DTOs.LeavesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.LeaveContracts;

namespace Services.AttendanciesServieces
{
    public class LeaveGetterService : ILeaveGetterService
    {
        private readonly ILeaveRequestRepository _leaveRepository;

        public LeaveGetterService(ILeaveRequestRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public async Task<List<LeaveResponse>> GetAllLeaves(Guid EmployeeId)
        {            

            // Retrieve all leave requests for the specified employee from the data store using the repository
            var leaves= await _leaveRepository.GetAllLeaveRequestsByEmployeeId(EmployeeId);

            // Map the retrieved leave requests to a list of LeaveResponse objects and return it
            return [.. leaves.Select(l => l.ToLeaveResponse())];  //=> return leaves.Select(l => l.ToLeaveResponse()).ToList();
        }

        public async Task<LeaveResponse> GetById(Guid id)
        {
            // retrieve the leave request with the specified ID from the data store using the repository
            var leave = await _leaveRepository.GetLeaveRequestById(id);

            return leave.ToLeaveResponse();

        }
    }
}
