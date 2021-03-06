using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_api_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_api_project.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context,IConfiguration configuration)
        {
             _configuration = configuration;
            _context = context;
           
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response=new ServiceResponse<string>();
            var user=await _context.Players.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            if(user == null)
            {
                response.Success=false;
                response.Message="User Not found";
            }

            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success=false;
                response.Message="Wrong Password";

            }
            else
            {
                // response.Data=user.Id.ToString();
                response.Data=CreateToken(user);

            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(Player user, string password)
        {
            ServiceResponse<int> response=new ServiceResponse<int>();
            if(await UserExists(user.Username))
            {
                response.Success=false;
                response.Message="User Already Exists";
                return response;
            }
            CreatePasswordHash(password,out byte[] passwordHash,out byte[] passwordSalt);
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;
            _context.Players.Add(user);
            await _context.SaveChangesAsync();
            
            response.Data=user.Id;
            return response; 

        }



        public async Task<bool> UserExists(string username)
        {
            if(await _context.Players.AnyAsync(x => x.Username.ToLower().Equals(username.ToLower())))
            {
                return true;

            }
            return false;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passowrdHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0;i<computeHash.Length;i++)
                {
                    if(computeHash[i] != passowrdHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        private string CreateToken(Player user)
        {
            var claims=new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)   

            };

            var key=new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescripter=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(claims),
                Expires=System.DateTime.Now.AddDays(1),
                SigningCredentials=creds 
            };

            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescripter);

            //to get token in json string
            return tokenHandler.WriteToken(token);
        }
    }
}

