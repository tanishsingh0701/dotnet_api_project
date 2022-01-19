using System.Threading.Tasks;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Dtos.Weapon;
using dotnet_api_project.Models;
using dotnet_api_project.Service.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController:ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weaponService.AddWeapon(newWeapon));
            
        }
        
    }
}