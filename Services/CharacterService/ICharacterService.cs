using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Models;

namespace dotnet_api_project.Service.CharacterService
{
    public interface ICharacterService
    {
        // List<Character> GetAllCharacter();
        // Character GetCharacterById(int id);
        // List<Character> AddCharacter(Character newCharacter);

        //Implemention Async

        // Task<List<Character>> GetAllCharacter();
        // Task<Character> GetCharacterById(int id);
        // Task<List<Character>> AddCharacter(Character newCharacter);


        // For adding own service Response

         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacterDto(UpdateCharacterDto updatedCharacter);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        
    }

}