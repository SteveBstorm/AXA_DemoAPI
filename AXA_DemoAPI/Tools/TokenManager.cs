using AXA_DemoAPI.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AXA_DemoAPI.Tools
{
    public class TokenManager
    {
        private string _audience, _issuer;

        public TokenManager(IConfiguration config)
        {
            _audience = config.GetSection("InfoToken").GetSection("myAudience").Value;
            _issuer = config.GetSection("InfoToken").GetSection("myAudience").Value;
        }

        public string GenerateToken(UserLogin user)
        {
            //generate signin key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma super clé secrete"));
            SigningCredentials credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //payload
            Claim[] myclaims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, (user.IsAdmin) ? "Admin" : "User"),
                new Claim("toto", "value")
            };

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: myclaims,
                signingCredentials: credential,
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(securityToken);
        }
    }
}
