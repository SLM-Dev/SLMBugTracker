using Microsoft.EntityFrameworkCore;
using SLMBugTracker.Data;
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
            List<BTUser> result = new();

            result = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();

            return result;
        }

        public async Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            List<Project> result = new();

            result = await _context.Projects.Where(p => p.CompanyId == companyId)
                                   .Include(p => p.Members)
                                   .Include(p => p.Tickets)
                                       .ThenInclude(t => t.Comments)
                                   .Include(p => p.Tickets)
                                       .ThenInclude(t => t.TicketStatus)
                                   .Include(p => p.Tickets)
                                       .ThenInclude(t => t.TicketPriority)
                                   .Include(p => p.Tickets)
                                       .ThenInclude(t => t.TicketType)
                                   .Include(p => p.ProjectPriority)
                                   .ToListAsync();


            return result;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {

        }

        public Task<Company> GetCompanyInfoByIdAsync(int? company)
        {
            throw new NotImplementedException();
        }
    }
}
