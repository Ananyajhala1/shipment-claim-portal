using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.LoginService
{
    public interface ILoginService
    {
         Task<AuthDTO> Login(string username, string password, IConfiguration config);




    }
}
