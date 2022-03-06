using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketComment
    {

        public int Id { get; set; }
        
        //Data Annotations
        [Display(Name = "Member Comment")]
        public string Comment { get; set; }
        

        //Created
        [Display(Name = "Date")]
        public DateTimeOffset Created { get; set; }
        
        //Ticket Id
        //Create a foreign key for the Ticket
        [Display(Name = "Ticket")]
        public int TicketId { get; set; }
        
        //UserId
        //Creats a foreign key for the Team Member
        [Display(Name = "Team Member")]

        public string UserId { get; set; }


        //--Navigation properties--//
        //Ticket
        public virtual Ticket Ticket { get; set; }
        
        //User
        public virtual BTUser User { get; set; }







    }
}
