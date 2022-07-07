using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{  
    [Table("city")]
    public  class CityT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

    }
}
