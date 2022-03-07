using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class Invite
    {

        //  Primary Key
        public int Id { get; set; }

        [DisplayName("Date Sent")]

        public DateTimeOffset InviteDate { get; set; }


        // foreign key for Company

        [DisplayName("Join Date")]
        public DateTimeOffset Created { get; set; }


        [DisplayName("Code")]
        public Guid CompanyToken { get; set; }
    

    // foreign key for Company

        [DisplayName("Company")]

        public int CompanyId { get; set; }

        [DisplayName("Project")]

        public int ProjectId { get; set; }


        [DisplayName("Invitor")]

        public string InvitorId { get; set; }


        [DisplayName("Invitee")]

        public string InviteeId { get; set; }
        

        [DisplayName("Invitee Email")]
        public string InviteeEmail { get; set; }

        [DisplayName("Invitee First Name")]
        public string InviteeFirstName { get; set; }


        [DisplayName("Invitee Last Name")]
        public string InviteeLastName { get; set; }


        // Create a flag indicating whether the invitee is valid or not.


        public bool IsValid { get; set; }

        // Navigation Properties

        public virtual Company Company { get; set; }

        public virtual Project Project { get; set; }

        public virtual BTUser Invitor { get; set; }

        public virtual BTUser Invitee { get; set; }

        
        

       




    }
}
