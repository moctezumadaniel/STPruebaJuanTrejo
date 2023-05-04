using Microsoft.IdentityModel.Tokens;
using PruebaSTJuanTrejo.Business.Services.Customers;
using PruebaSTJuanTrejo.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaSTJuanTrejo.Business.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ICustomersService _customersService;
        private readonly IConfiguration _configuration;
        public AuthService(ICustomersService customersService,
            IConfiguration configuation)
        {
            _customersService = customersService;
            _configuration = configuation;
        }

        public Customer Authenticate(string jwt)
        {
            throw new NotImplementedException();
        }

        public string Login(string email, string password)
        {
            var customer = _customersService.GetCustomerByEmail(email);
            if(customer != null && customer.Password == password)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new List<Claim>
                {
                    new Claim("userId", customer.Id.ToString())
                };
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(720),
                    signingCredentials: credentials
                );
                
                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                return jwt;
            }
            else
            {
                return "";
            }
        }
    }
}
