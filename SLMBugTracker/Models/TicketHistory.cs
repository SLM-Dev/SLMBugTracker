using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        //Creats a foreign key for the Ticket

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        //Creates a foreign key for the User

        [DisplayName("Updated Item")]
        public string Property { get; set; }

        //Creates a foreign key for the TicketStatus

        [DisplayName("Previous")]
        public int OldValue { get; set; }

        //Creates a foreign key for the Current
        [DisplayName("Current")]
        public int NewValue { get; set; }

        //Create a foreign key for the Date
        [DisplayName("Date Modified")]
        public DateTimeOffset Created { get; set; }

        //Create a foreign key for the Description
        [DisplayName("Description of Change")]
        public string Description { get; set; }

        //Create a foreign key for the Team Member
        [DisplayName("Team Member")]
        public string UserId { get; set; }

        //Navigation properties
        public virtual Ticket Ticket { get; set; }

        public virtual BTUser User { get; set; }
    }
}


