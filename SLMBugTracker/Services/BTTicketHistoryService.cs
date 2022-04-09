﻿using Microsoft.EntityFrameworkCore;
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


                if (oldTicket.Title != newTicket.Title)
                { 


            // Check Ticket Title
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
            Property = "TicketTypeId",
            OldValue = oldTicket.TicketType.Name,
            NewValue = newTicket.TicketType.Name,
            Created = DateTimeOffset.Now,
            UserId = userId,
            Description = $"New ticket type: {newTicket.TicketType.Name}"
        };
        await _context.TicketHistories.AddAsync(history);
        }
        
        // Check Ticket Developer
        if (oldTicket.DeveloperUserId != newTicket.DeveloperUserId)
        {
            TicketHistory history = new()
            {
                TicketId = newTicket.Id,
                Property = "Developer",
                OldValue = oldTicket.DeveloperUser?.FullName ?? "Not Assigned",
                NewValue = newTicket.DeveloperUser?.FullName,
                Created = DateTimeOffset.Now,
                UserId = userId,
                Description = $"New ticket developer: {newTicket.DeveloperUser.FullName}"
            };
            await _context.TicketHistories.AddAsync(history);
        }
        
        try
        {
            
            // Save the TicketHistory DataBaseSet to the database
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

        throw;
        }
    }
 }

        public async Task AddHistoryAsync(int ticketId, string model, string userId)
        {
            try
            {
                Ticket ticket = await _context.Tickets.FindAsync(ticketId);
                string description = model.ToLower().Replace("Ticket", "");
                description = $"New {description} add to ticket: {ticket.Title}";
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId)
{
    try
    {
        List<Project> projects = (await _context.Companies
                                                .Include(c => c.Projects)
                                                .ThenInclude(p => p.Tickets)
                                                .ThenInclude(t => t.History)
                                                .ThenInclude(h => h.User)
                                                .FirstOrDefaultAsync(c => c.Id == companyId)).Projects.ToList();
        List<Ticket> tickets = projects.SelectMany(p => p.Tickets).ToList();
        List<TicketHistory> ticketHistories = tickets.SelectMany(t => t.History).ToList();
        return ticketHistories;
    }
    catch (Exception)
    {

        throw;
    }
}

public async Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId)
{
    try
    {
        Project project = await _context.Projects.Where(p => p.CompanyId == companyId)
                                                 .Include(p => p.Tickets)
                                                 .ThenInclude(t => t.History)
                                                 .ThenInclude(h => h.User)
                                                 .FirstOrDefaultAsync(p => p.Id == projectId);
        List<TicketHistory> ticketHistory = project.Tickets.SelectMany(t => t.History).ToList();
        return ticketHistory;
    }
    catch (Exception)
    {

        throw;
    
        }
    }
  }
}

