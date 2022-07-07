using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
     [Table("institutionType")]
    public class InstitutionTypeT
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitutionTypeID { get; set; }

        [Required]
        public string InstituitonType { get; set; }
    }
}
