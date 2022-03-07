using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace SLMBugTracker.Models
{
    public class BTUser : IdentityUser  
    {
        //Create a new property called FirstName
        [Required]
        
        // When using public properties, the first name is required
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
         
        // Field Cannot Be NULL
        [Required]
        
        [Display(Name = "Last Name")]
        //Create a new property called LastName
        public string LastName { get; set; }
        

        [NotMapped]
        //Create a new property called Full Name
         // When using public properties, the Full Name is required
        
        [Display(Name = "Full Name")]

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped]
        [DataType(DataType.Upload)]
        
       
        //IFormFile Avatar
        public IFormFile AvatarFormFile { get; set; }

        [DisplayName("Avatar")]

        public string AvatarFileName { get; set; }
        public byte[] AvatarFileData { get; set; }

        [Display(Name = "File Extension")]


        public string AvatarContentType { get; set; }


        public int? CompanyId { get; set; }


        //Navigation properties for the Company
        public virtual Company Company { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        



    }
}
