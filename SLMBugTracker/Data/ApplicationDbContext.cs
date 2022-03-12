using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SLMBugTracker.Models;

namespace SLMBugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<BTUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Create DbSets for each model


        //DbSet for Companies
        public DbSet<Company> Companies { get; set; }

        //DbSet for Invites
        public DbSet<Invite> Invites { get; set; }

        //DbSet for Projects
        public DbSet<Project> Projects { get; set; }

        //DbSet for Tickets
        public DbSet<Ticket> Tickets { get; set; }

        //DbSet for Ticket Notifications
        public DbSet<Notification> Notifications { get; set; }


        //DbSet for ProjectPriorities
        public DbSet<ProjectPriority> ProjectPriorities { get; set; }

        //DbSet for Ticket Attachments
        public DbSet<TicketAttachment> TicketAttachments { get; set; }

        //DbSet for Ticket Comments
        public DbSet<TicketComment> TicketComments { get; set; }

        //DbSet for Ticket Histories
        public DbSet<TicketHistory> TicketHistories { get; set; }

        //DbSet for Ticket Priorities
        public DbSet<TicketPriority> TicketPriorities { get; set; }


        //DbSet for Ticket Statuses
        public DbSet<TicketStatus> TicketStatuses { get; set; }


        //DbSet for Ticket Types
        public DbSet<TicketType> TicketTypes { get; set; }























    }
}
