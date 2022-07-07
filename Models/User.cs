using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Prayaas_Website.Models
{
    [Table("user")]
    public class User
    {
        [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public int AccountStatusID { get; set; }
        [ForeignKey("AccountStatusID")]
        public virtual AccountStatusT AccountStatus { get; set; }

        public int? UserTypeID { get; set; }
        [ForeignKey("UserTypeID")]
        public virtual UserTypeT UserType { get; set; }

        public virtual ICollection<Institution> Institution { get; set; }

        public virtual ICollection<Donor> Donor { get; set; }
        public virtual ICollection<Seeker> Seeker { get; set; }


    }
}