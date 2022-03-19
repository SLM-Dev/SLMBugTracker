﻿using Microsoft.AspNetCore.Identity.UI.Services;
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
    public class BTNotification : IBTNotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IBTRolesService _rolesService;

        public BTNotification(ApplicationDbContext context,
                              IEmailSender emailSender,
                              IBTRolesService rolesService)
        {
            _context = context;
            _emailSender = emailSender;
            _rolesService = rolesService;
        }
        public async Task AddNotificationAsync(Notification notification)
        {
            try
            {
                await _context.AddAsync(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Notification>> GetRecievedNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                     .Include(u => u.Recipient)
                                                                     .Include(u => u.Sender)
                                                                     .Include(u => u.Ticket)
                                                                          .ThenInclude(t => t.Project)
                                                                     .Where(n => n.RecipientId == userId).ToListAsync();
                return notifications;


            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<List<Notification>> GetSentNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                     .Include(u => u.Recipient)
                                                                     .Include(u => u.Sender)
                                                                     .Include(u => u.Ticket)
                                                                          .ThenInclude(t => t.Project)
                                                                     .Where(n => n.SenderId == userId).ToListAsync();
                return notifications;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject)
        {
            BTUser btUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == notification.RecipientId);

            if (btUser != null)
            {
                string btUserEmail = btUser.Email;
                string message = notification.Message;

                // Send Email
                try
                {
                    await _emailSender.SendEmailAsync(btUserEmail, emailSubject, message);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        public Task SendEmailNotificationsByRoleAsync(Notification notification, int companyId, string role)
        {
            throw new NotImplementedException();
        }

        public Task SendMembersEmailNotificationsAsync(Notification notification, List<BTUser> members)
        {
            throw new NotImplementedException();
        }
    }
}
