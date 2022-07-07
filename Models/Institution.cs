using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
    [Table("institution")]
    public  class Institution
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitutionID { get; set; }

        [Required]
        [StringLength(50)]
        public string InstitutionName { get; set; }

        public int InstitutionTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Website { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public int CityID { get; set; }

        public int UserID { get; set; }

        [ForeignKey("InstituionTypeID")]
        public virtual InstitutionTypeT InstitutionType { get; set; }
        [ForeignKey("CityID")]
        public virtual CityT City { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
