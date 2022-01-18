using AutoMapper;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Models;

namespace dotnet_api_project
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character >();
            
        }

        public MemberList Character { get; }
    }
}