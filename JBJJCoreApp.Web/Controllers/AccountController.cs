using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JBJJCoreApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using User.Domain;

namespace JBJJCoreApp.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<JBJJUser> _signInManager;
        private UserManager<JBJJUser> _userManager;
        private IConfiguration _configuration;

        public AccountController(SignInManager<JBJJUser> signInManager, UserManager<JBJJUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> CreateToken([FromBody]LoginViewModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(value.Username);

                    if (user != null)
                    {
                        var result = await _signInManager.CheckPasswordSignInAsync(user, value.Password, false);

                        if (result.Succeeded)
                        {
                            // Create the token
                            var claims = new[]
                            {
                              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                            };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var token = new JwtSecurityToken(
                                _configuration["Tokens:Issuer"],
                                _configuration["Tokens:Audience"],
                                claims,
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials: creds);

                            var results = new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expiration = token.ValidTo
                            };

                            return Created("", results);
                        }
                    }
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}