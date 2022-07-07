using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
    [Table("accountStatus")]
    public class AccountStatusT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountStatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string accountStatus { get; set; }
    }
}
