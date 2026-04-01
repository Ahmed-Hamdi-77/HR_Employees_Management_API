using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly API_DbContext _DbContext;

        public LeaveRequestRepository(API_DbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<LeaveRequest> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            await _DbContext.Leaves.AddAsync(leaveRequest);
            await _DbContext.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task DeleteLeaveRequest(Guid leaveRequestId)
        {
            var leave = await _DbContext.Leaves.FirstOrDefaultAsync(l => l.id == leaveRequestId) ?? throw new KeyNotFoundException($"LeaveRequest with ID {leaveRequestId} is not found."); 
            
             _DbContext.Leaves.Remove(leave);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsByEmployeeId(Guid employeeId)
        {
            return await _DbContext.Leaves.Where(l=>l.EmployeeId==employeeId).ToListAsync() ?? throw new KeyNotFoundException($"Employee with ID {employeeId} is not found.");
        }

        public async Task<LeaveRequest> GetLeaveRequestById(Guid leaveRequestId)
        {
            return await _DbContext.Leaves.FirstOrDefaultAsync(l => l.id == leaveRequestId) ?? throw new KeyNotFoundException($"LeaveRequest with ID {leaveRequestId} is not found.");

        }

        public async Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            var matchedLeaveRequest = await _DbContext.Leaves.FirstOrDefaultAsync(l => l.id == leaveRequest.id) ?? throw new KeyNotFoundException("LeaveRuquest is not found."); ;
            
            matchedLeaveRequest.FromDate=leaveRequest.FromDate;
            matchedLeaveRequest.ToDate=leaveRequest.ToDate;            
            matchedLeaveRequest.Type=leaveRequest.Type;                        
            await _DbContext.SaveChangesAsync();

            return matchedLeaveRequest;
        }
    }
}
