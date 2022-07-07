using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Prayaas_Website.Models
{
     [Table("seeker")]
    public  class Seeker
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeekerID { get; set; }

       
        [StringLength(50)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [StringLength(50)]
        public string ContactNo { get; set; }

      
        [StringLength(50)]
        public string Adhaar { get; set; }
       
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public int BloodGroupID { get; set; }
        [ForeignKey("BloodGroupID")]
        public virtual BloodGroups BloodGroups { get; set; }

        public int CityID { get; set; }

        [ForeignKey(" CityID")]
        public virtual CityT City { get; set; }

        public int GenderID { get; set; }

        [ForeignKey("GenderID")]
        public virtual GenderT Gender { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
