using CIM.Models;
using CIM.Repo.Implementation;
using CIM.Repo.Interface;
using CIM.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CIM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _cusRepo;
        public CustomersController(ICustomerRepo cusRepo)
        {
            this._cusRepo = cusRepo;
        }
        [HttpGet]
        [Route("/api/Customers/GetCustomerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCustomerList()
        {
            try
            {
                return Ok(_cusRepo.GetCustomers().ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/Customers/SaveCustomer")]
        public IActionResult SaveCustomer([FromForm,FromBody] CustomerHelper customer)
        {
            try
            {
                if((customer.CustomerPhoto!=null) || customer.ID > 0)
                {
                    Customer customerToSave=customer.GetCustomer();
                    _cusRepo.SaveCustomerData(customerToSave);
                    customerToSave.CustomerAddresses = new System.Collections.Generic.List<CustomerAddress>();
                    return Ok(customerToSave);
                }
                else
                {
                    return BadRequest("Please provide Image!!!");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
