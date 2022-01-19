using System.Collections.Generic;
using dotnet_api_project.Dtos.Weapon;
using dotnet_api_project.Dtos.Skill;
namespace dotnet_api_project.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }="Tanish";
        public int HitPoints { get; set; }=100;
        public int Strength { get; set; }=10;

        public int Defence { get; set; }=10;

        public int Intelligence { get; set; }=10;
        public RpgClass Class { get; set; }=RpgClass.knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skills { get; set; }
         public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}