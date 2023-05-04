using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Business.Services.Auth
{
    public interface IAuthService
    {
        string Login(string email, string password);
        Customer Authenticate(string jwt);
    }
}
