using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
     [Table("bloodGroups")]
    public class BloodGroups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodGroupID { get; set; }

        [Required]
        [StringLength(5)]
        public string BloodGroup { get; set; }
    }
}
