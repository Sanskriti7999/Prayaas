using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
 
    [Table("Gender")]
    public  class GenderT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenderID { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
