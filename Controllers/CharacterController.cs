using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_api_project.Dtos;
using dotnet_api_project.Dtos.Character;
using dotnet_api_project.Models;
using dotnet_api_project.Service.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        // private static Character Knight=new Character();
        //now creating list of character cass

        // private static List<Character> characters=new List<Character>
        // {
        //     new Character(),
        //     new Character{Id=1, Name="Frodo"},

        // };


        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }



        // public IActionResult Get()
        // {
        //     // returning 200 status ok 
        //     return Ok(Knight);
        // }
        // [HttpGet]
        // [Route("GetAll")]

       
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            // int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
             
   
            // returning 200 status ok 
            return Ok(await _characterService.GetAllCharacter());
        }


[HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            // return Ok(_characterService.GetCharacterById(id));
             return Ok(await _characterService.GetCharacterById(id));

        }


[HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            // return Ok(_characterService.AddCharacter(newCharacter));
            return Ok(await _characterService.AddCharacter(newCharacter));
        }



        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response=await _characterService.UpdateCharacterDto(updatedCharacter);

            if(response.Data==null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response=await _characterService.DeleteCharacter(id);

            if(response.Data==null)
            {
                return NotFound(response);
            }
            
             return Ok(response);



        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
            
        }

    }
}