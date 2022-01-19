using AutoMapper;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Dtos.Fight;
using dotnet_api_project.Dtos.Skill;
using dotnet_api_project.Dtos.Weapon;
using dotnet_api_project.Models;

namespace dotnet_api_project
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon,GetWeaponDto>();
            CreateMap<Skill,GetSkillDto>();
            CreateMap<Character,HighScoreDto>();
            
        }

        public MemberList Character { get; }
    }
}