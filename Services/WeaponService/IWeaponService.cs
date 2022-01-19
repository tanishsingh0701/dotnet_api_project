using System.Threading.Tasks;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Dtos.Weapon;
using dotnet_api_project.Models;

namespace dotnet_api_project.Service.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}