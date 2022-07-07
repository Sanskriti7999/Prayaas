using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{
    [Table("request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequestDate { get; set; }

        public string MemberName { get; set; }
        [ForeignKey("UserTypeID")]
        public virtual UserTypeT UserType { get; set; } 

        public string Quantity { get; set; }

        public string Contact { get; set; }

        [ForeignKey("CityID")]
        public virtual  CityT City { get; set; } 

        [ForeignKey("RequestTypeID")]
        public virtual RequestTypeT RequestType { get; set; }

        [Column("RequiredBloodGroup")]
        [ForeignKey("BloodGroupID")]
        public virtual BloodGroups BloodGroups { get; set; }
    }
}
