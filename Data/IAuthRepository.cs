using System.Threading.Tasks;
using dotnet_api_project.Models;

namespace dotnet_api_project.Data
{
    public interface IAuthRepository
    {
        
        Task<ServiceResponse<int>> Register(Player user,string password);
        Task<ServiceResponse<string>> Login(string username,string password);
        Task<bool> UserExists(string username);
        
    }
}