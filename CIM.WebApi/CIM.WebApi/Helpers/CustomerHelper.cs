using CIM.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace CIM.WebApi.Helpers
{
    public class CustomerHelper
    {
        public CustomerHelper()
        {

        }
        public CustomerHelper(Customer customer)
        {
            this.ID = customer.ID;
            this.CountryID = customer.CountryId;
            this.CustomerName= customer.CustomerName;
            this.FatherName= customer.FatherName;
            this.MotherName= customer.MotherName;
            this.MaritalStatus= customer.MaritalStatus;
            this.CustomerPhoto = ConvertByteToFile(customer.CustomerPhoto);
            this.Country = customer.Country;
            this.CustomerAddresses= customer.CustomerAddresses;
        }
        public int? ID { get; set; }
        public int CountryID { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public IFormFile CustomerPhoto { get; set; }
        public Country Country { get; set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.ID=this.ID==null?0: (int)this.ID;
            c.CountryId=this.CountryID;
            c.CustomerName=this.CustomerName;
            c.FatherName=this.FatherName;
            c.MotherName=this.MotherName;
            c.MaritalStatus=this.MaritalStatus;
            c.CustomerPhoto=ConvertFileToByte(this.CustomerPhoto);
            c.CustomerAddresses = this.CustomerAddresses;
            return c;
        }
        private byte[] ConvertFileToByte(IFormFile file)
        {
            byte[] fileBytes=null;
            if(file!=null)
            {
                if(file.Length>0)
                {
                    using(var ms=new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes=ms.ToArray();
                    }
                }
            }
            return fileBytes;
        }
        private IFormFile ConvertByteToFile(byte[] byteArray)
        {
            var stream = new MemoryStream(byteArray);
            IFormFile file=new FormFile(stream,0,byteArray.Length,"name","fileName");
            return file;
        }
    }
}
