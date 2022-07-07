using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models

{
  
    [Table("userType")]
    public  class UserTypeT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; }
    }
}
