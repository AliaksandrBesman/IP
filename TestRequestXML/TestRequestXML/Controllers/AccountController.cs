using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestRequestXML.Models; // класс Person
using Newtonsoft.Json.Linq;

namespace TestRequestXML.Controllers
{
   [ApiController]
    public class AccountController : Controller
    {
        private readonly graduateprojectsContext _context;

        public AccountController(graduateprojectsContext context)
        {
            _context = context;
        }

        [HttpPost("/token")]
        public IActionResult Token([FromBody] JObject data)
        {
            string username = data["login"].ToObject<string>();
            string password = data["password"].ToObject<string>();
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            string role = identity.Claims.Where(x => x.Type == identity.RoleClaimType).Select(x => x.Value).FirstOrDefault();
            var response = new
            {
                id = _context.Users.FirstOrDefault(x => x.Login == username).Id,
                access_token = encodedJwt,
                login = identity.Name,
                role = role
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            UsersRolesView person = _context.UsersRolesView.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.RoleName)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
