using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prayaas_Website.Models
{
    public class UserModel
    {

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public int? UserTypeID { get; set; }
        public int? UserID { get; set; }

    }
}
