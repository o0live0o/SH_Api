using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChargeApi.Service
{
    public abstract class JWTServices
    {

        public static string GetToken()
        {
            var cliams = new Claim[] {
                new Claim(ClaimTypes.Name,"Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789012345"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: cliams,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
