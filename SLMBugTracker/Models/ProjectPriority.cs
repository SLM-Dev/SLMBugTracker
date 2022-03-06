    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class ProjectPriority
    {
        //Primary Key
        public int Id { get; set; }

        // [Required]
        // [StringLength(50)]
        [DisplayName("Priority")]
        public string Name { get; set; }

    
    }
}
