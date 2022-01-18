using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_api_project.Data;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api_project.Service.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters=new List<Character>
        {
            new Character(),
            new Character{Id=1, Name="Frodo"},

        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            
            _context = context;
        }



        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {

            // characters.Add(newCharacter);
            // return characters;

            // doing for new ServiceResponse data

            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            Character character=_mapper.Map<Character>(newCharacter);

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            // character.Id=characters.Max(c => c.Id)+1;            
            // characters.Add(character);   
            
            // serviceResponse.Data=characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data=await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            try{
            // Character character=characters.First(c => c.Id==id);
            Character character=await _context.Characters.FirstAsync(c => c.Id==id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            // serviceResponse.Data=characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data= _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=e.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            
            // return characters;

            // doing for new Service Response


            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            var dbCharacters=await _context.Characters.ToListAsync();
            // serviceResponse.Data=characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data=dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;

        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            //  return characters.FirstOrDefault(c => c.Id == id);

            // doing for servcie Response

            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            var dbCharacter=await _context.Characters.FirstOrDefaultAsync(c => c.Id==id);
            // serviceResponse.Data=_mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id==id));
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;


        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacterDto(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();

            try{
            // Character character=characters.FirstOrDefault(c => c.Id==updatedCharacter.Id);
             Character character=await _context.Characters.FirstOrDefaultAsync(c => c.Id==updatedCharacter.Id);
            character.Name=updatedCharacter.Name;
            character.HitPoints=updatedCharacter.HitPoints;
            character.Strength=updatedCharacter.Strength;
            character.Defence=updatedCharacter.Defence;
            character.Intelligence=updatedCharacter.Intelligence;
            character.Class=updatedCharacter.Class;
            await _context.SaveChangesAsync();
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception e)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=e.Message;
            }
            return serviceResponse;


            
        }
    }
}