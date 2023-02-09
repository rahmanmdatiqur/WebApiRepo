using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CIM.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        [Column(TypeName ="VARBINARY(MAX)")]
        public byte[] CustomerPhoto { get; set; }

        //nev
        public Country Country { get;set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }
    }
}
