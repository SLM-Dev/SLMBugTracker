using SLMBugTracker.Models;
using SLMBugTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Services
{
    public class BTCompanyInfoService : IBTCompanyInfoService
    {
        private readonly ApplicationDbContext _context;

        public BTCompanyInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            List<BTUser> result = new List<BTUser>();

            result = await _context.BTUsers.Where(u => u.CompanyId == companyId).ToListAsync();

            return result;
        }

        public Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyInfoByIdAsync(int? company)
        {
            throw new NotImplementedException();
        }
    }
}
