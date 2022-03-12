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
        public Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            throw new NotImplementedException();
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
