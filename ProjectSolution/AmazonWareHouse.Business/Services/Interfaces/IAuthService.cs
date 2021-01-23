using AmazonWareHouse.Business.Models.Users;
using System.Threading.Tasks;

namespace AmazonWareHouse.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(LoginModel model);

        Task<string> GenerateToken(UserAuthModel user);
    }
}
