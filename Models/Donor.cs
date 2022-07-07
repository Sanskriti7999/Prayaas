using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
    [Table("donor")]
    public class Donor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonorID { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string FullName { get; set; }

        public int BloodGroupID { get; set; }

        [ForeignKey("BloodGroupID")]
        public virtual BloodGroups BloodGroups { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastDonationDate { get; set; }

        [Required]
        [StringLength(17)]
        public string Adhaar { get; set; }

        [Required]
        [StringLength(300)]
        public string Location { get; set; }

        [Required]
        [StringLength(15)]
        public string ContactNo { get; set; }

        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual CityT City { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public int GenderID { get; set; }

        [ForeignKey("GenderID")]
        public virtual GenderT Gender { get; set; }

    }
}

