using Blazor_Catalogo.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Catalogo.Server.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        
        public AccountController( UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserInfo model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Password
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return GenerateToken(model);
            }
            else
            {
                return BadRequest(new { message = "senha ou nome do usuario invalidos...." });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login ([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                return BadRequest(new { message = "login inválido." });
            }
        }
        private UserToken GenerateToken(UserInfo userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim("mac","macoratti.net"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);
            var message = "Token JWT craido com sucesso";

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = message
            };
        }



       


    }
}
