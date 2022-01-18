using System.Threading.Tasks;
using dotnet_api_project.Data;
using dotnet_api_project.Dtos;
using dotnet_api_project.Dtos.User;
using dotnet_api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response=await _authRepo.Register(
                new Player{Username=request.Username},request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response=await _authRepo.Login(
                request.Username,request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
            
        }
        
    }
}