using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CIM.Models
{
    public class CustomerAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Column(name:"CustomerAddress",TypeName ="NVARCHAR(500)")]
        public string Address { get; set; }
        //nev
        public Customer Customer { get; set; }
    }
}
