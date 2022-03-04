using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        [DisplayName("Type Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }

}
