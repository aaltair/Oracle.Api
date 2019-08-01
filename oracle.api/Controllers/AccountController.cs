using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using oracle.api.Dtos;
using oracle.api.Entities.User;

namespace oracle.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username); //for orcale db 
            if(user==null) return Unauthorized(); //for orcale db 
            await _userManager.UpdateSecurityStampAsync(user); //for orcale db 
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username,loginDto.Password,false,false);
            if (result.Succeeded) return await GenerateToken(loginDto.Username, loginDto.Password);
            return Unauthorized();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }



        private async Task<IActionResult> GenerateToken(string userName, string password)
        {

            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            var now = DateTime.Now;
            var userClaims = await _userManager.GetClaimsAsync(user);
            userClaims.Add(new Claim("Id", user.Id));
            userClaims.Add(new Claim("Name", user.UserName));
            foreach (var role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));

            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.Ticks.ToString(), ClaimValueTypes.Integer64)
            }.Union(userClaims);


            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Audience")["Secret"])),
                SecurityAlgorithms.HmacSha256);

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _configuration.GetSection("Audience")["Iss"],
                audience: _configuration.GetSection("Audience")["Aud"],
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromDays(1)),
                signingCredentials: signingCredentials);

            return Ok(new
            {

                Id = user.Id,

                FullName = user.FirstName + " " + user.SecondName + " " + user.LastName,
                FullNameEn = user.FirstNameEn + " " + user.SecondNameEn + " " + user.LastNameEn,
                ProfileImg = user.ProfileImg,
                token = new JwtSecurityTokenHandler().WriteToken(jwt),
                expiration = jwt.ValidTo,
                Roles = roles,

            });

        }

    



}
}