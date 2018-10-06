using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//
using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }//PK

        [Required]  //LOGICALY IS A FK
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public string Address { get; set; }
    }
}
