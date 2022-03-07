using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketComment
    {

        public int Id { get; set; }

        //Data Annotations
        [DisplayName("Member Comment")]
        public string Comment { get; set; }


        //Created
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        //Ticket Id
        //Create a foreign key for the Ticket
        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        //UserId
        //Creats a foreign key for the Team Member
        [DisplayName("Team Member")]

        public string UserId { get; set; }


        //--Navigation properties--//
        //Ticket
        public virtual Ticket Ticket { get; set; }
        
        //User
        public virtual BTUser User { get; set; }







    }
}
