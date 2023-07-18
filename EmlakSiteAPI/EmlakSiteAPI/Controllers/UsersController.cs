using BCrypt.Net;
using EmlakSiteAPI.Application.Repositories.Users;
using EmlakSiteAPI.Application.ViewModel.Users;
using EmlakSiteAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmlakSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UsersController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(Vm_Users_Login VmLogin)
        {
            var user = _userReadRepository.GetWhere(data=>data.Email == VmLogin.Email).FirstOrDefault();
            if (user == null)
                return Ok("Böyle Bir Kullanıcı Bulunamadı");

            bool match = BCrypt.Net.BCrypt.Verify(VmLogin.Password, user.Password);
            if (match)
            {
                return Ok(new { state = true, userId = user.Id });
                //var jwtHandler = new JwtHandler("helloworld", "myIssuer", "myAudience", 60 * 24);
                //var token = jwtHandler.GenerateJwtToken(user.Id.ToString(), user.Username);
            }


            return Ok(new { state = false });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Vm_Users_Register vmRegister)
        {
            var user = _userReadRepository.GetWhere(data => data.Email == vmRegister.Email).FirstOrDefault();
            if (user != null)
                return Ok(false);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(vmRegister.Password);
            var newuser = await _userWriteRepository.AddAsync(new()
            {
                Email = vmRegister.Email,   
                Username = vmRegister.Username,
                Password = hashedPassword,
                isAdmin = false,
            });

            //var token = new JwtSecurityTokenHandler().CreateToken(new SecurityTokenDescriptor(){
            //    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, newuser.Id)
            //    })
            //});

            await _userWriteRepository.SaveAsync();

            return Ok(newuser);
        }

    }
}
