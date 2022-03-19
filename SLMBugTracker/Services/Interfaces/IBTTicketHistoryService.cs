using SLMBugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Services.Interfaces
{
    public interface IBTTicketHistoryService
    {
     Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId);

     Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId);
    } 
}
