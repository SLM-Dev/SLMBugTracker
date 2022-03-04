using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SLMBugTracker.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }
        
        [DisplayName("Status Name")]
        public string Name { get; set; }
                
    }
}
