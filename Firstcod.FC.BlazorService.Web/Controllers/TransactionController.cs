using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstcod.FC.BlazorService.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var claim = new Claim[]
            {
                new Claim(ClaimTypes.Name, "firstcod@firstcod.com"),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddSeconds(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12345@firstcod@54321")), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = new JwtSecurityTokenHandler().CreateToken(securityTokenDescriptor);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = jwt });
        }

        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(id);
        }

        [Authorize(Roles = "Manager, Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {
                return Ok(value);
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(id + " - " + value);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
