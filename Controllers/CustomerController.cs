using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaSTJuanTrejo.Business.Services.Customers;
using PruebaSTJuanTrejo.Data.Repositories.Customers;
using PruebaSTJuanTrejo.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace PruebaSTJuanTrejo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService _customersService;
        public CustomerController(ICustomersRepository customersRepository,
            ICustomersService customersService
           )
        {
            _customersService = customersService;
        }
        [HttpPost]
        [Route("/Customers")]
        [Authorize]

        public IActionResult CreateCustomer(
            [FromBody]CustomerToCreate customer)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new Customer
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    EmailAddress = customer.EmailAddress,
                    LastName = customer.LastName,
                    Password = customer.Password
                };
                var result = _customersService.CreateCustomer(newCustomer);
                return new JsonResult(result);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        [HttpGet]
        [Route("/Customers")]
        [Authorize]

        public IActionResult GetCustomer(
            [FromQuery]int limit)
        {
            var result = _customersService.ReadCustomers(limit);
            return new JsonResult(result);
        }

        [HttpPut]
        [Route("/Customers")]
        [Authorize]

        public IActionResult EditCustomer(
            [FromBody] Customer customer)
        {
            var result = _customersService.UpdateCustomer(customer);
            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("/Customers/{guid}")]
        [Authorize]

        public IActionResult DeleteCustomer(
            [FromRoute] Guid guid)
        {
            var result = _customersService.DeleteCustomer(guid);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("/Customers/Items")]
        [Authorize]

        public IActionResult GetCustomerItems(
            [FromHeader] string authorization)
        {
            var jwt = authorization.Split()[1];
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(jwt);
            var payload = token.Payload;
            var userId = Guid.Parse(payload["userId"].ToString());
            var result = _customersService.GetCustomerItems(userId);
            return new JsonResult(result);
        }
    }
}
