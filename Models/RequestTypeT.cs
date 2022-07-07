using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prayaas_Website.Models
{

    [Table("requestType")]
    public  class RequestTypeT
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestTypeID { get; set; }

        [Required (ErrorMessage ="Required*")]
        [StringLength(50)]
        public string RequestType { get; set; }
    }
}
