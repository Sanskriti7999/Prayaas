using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
    [Table("bloodStock")]
    public class BloodStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodStockID { get; set; }

        public int BloodGroupID { get; set; }

        public int InstitutionID { get; set; }

        public int Quantity { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [ForeignKey("InstitutionID")]
        public virtual Institution Institution { get; set; }

        [ForeignKey("BloodGroupID")]
        public virtual BloodGroups BloodGroups { get; set; }
    }
}
