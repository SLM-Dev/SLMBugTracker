using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        //Creats a foreign key for the Ticket
        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        //Create a foreign key for the Date
        [DisplayName("File Date")]
        public DateTimeOffset Created { get; set; }

 
        //Create a foreign key for the Team Member
        [DisplayName("Team Member")]
        public string UserId { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]

        // Manupliation Properties
        public IFormFile FormFile { get; set; }
        [DisplayName("File Name")]
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        [DisplayName("File Extension")]
        public string FileContentType { get; set; }
        


        //Navigation properties
        public virtual Ticket Ticket { get; set; }

        public virtual BTUser User { get; set; }    


    }
}
