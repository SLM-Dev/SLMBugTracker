using SLMBugTracker.Data;
using SLMBugTracker.Models;
using SLMBugTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Services
{
    public class BTTicketHistoryService : IBTTicketHistoryService
    {
        private readonly ApplicationDbContext _context;

        public BTTicketHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId)
        {
            // NEW TICKET HAS BEEN ADDED
            if (oldTicket == null && newTicket != null)
            else
            {

                TicketHistory history = new()
                { 
                    TicketId = newTicket.Id,
                    Property = "",
                    OldValue = "",
                    NewValue = "",
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = "New Ticket Created"
            };

            try
            {
                await _context.TicketHistories.AddAsync(history);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        else
        {
            // Check Ticket Title
            if (oldTicket.Title != newTicket.Title)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "Title",
                    OldValue = oldTicket.Title,
                    NewValue = newTicket.Title,
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = $"New ticket title: {newTicket.Title}"
                };
                await _context.TicketHistories.AddAsync(history);
            }
            // Check Ticket Description
            if (oldTicket.Description != newTicket.Description)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "Description",
                    OldValue = oldTicket.Description,
                    NewValue = newTicket.Description,
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = $"New ticket description: {newTicket.Description}"
                };
                await _context.TicketHistories.AddAsync(history);
            }
            // Check Ticket Priority
            if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "TicketPriority",
                    OldValue = oldTicket.TicketPriority.Name,
                    NewValue = newTicket.TicketPriority.Name,
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = $"New ticket priority: {newTicket.TicketPriority.Name}"
                };
                await _context.TicketHistories.AddAsync(history);
            }
            // Check Ticket Status
            if (oldTicket.TicketStatusId != newTicket.TicketStatusId)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "TicketStatus",
                    OldValue = oldTicket.TicketStatus.Name,
                    NewValue = newTicket.TicketStatus.Name,
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = $"New ticket Status: {newTicket.TicketStatus.Name}"
                };
                await _context.TicketHistories.AddAsync(history);
            }
    
            // Check Ticket Type
            if (oldTicket.TicketTypeId != newTicket.TicketTypeId)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "TicketType",
                    OldValue = oldTicket.TicketType.Name,
                    NewValue = newTicket.TicketType.Name,
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = $"New ticket type: {newTicket.TicketType.Name}"
                };
                await _context.TicketHistories.AddAsync(history);
            }
            


    public Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId)
    {
        throw new NotImplementedException();
    }

    public Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId)
    {
        throw new NotImplementedException();
    }
}

