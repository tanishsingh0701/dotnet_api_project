using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_project.Dtos.Fight;
using dotnet_api_project.Models;

namespace dotnet_api_project.Service.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);
        Task<ServiceResponse<List<HighScoreDto>>> GetHighScore();
    }
}