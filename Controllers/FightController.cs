using System.Threading.Tasks;
using dotnet_api_project.Dtos.Fight;
using dotnet_api_project.Models;
using dotnet_api_project.Service.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController:ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService FightService)
        {
            _fightService = FightService;
        }
        

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));
            
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
            
        }

         [HttpPost("Fight")]
        public async Task<ActionResult<ServiceResponse<FightResultDto>>> Fight(FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));
            
        }

        [HttpGet("HighScore")]
        public async Task<ActionResult<ServiceResponse<HighScoreDto>>> GetHighScore()
        {
            return Ok(await _fightService.GetHighScore());
        }
    }
}