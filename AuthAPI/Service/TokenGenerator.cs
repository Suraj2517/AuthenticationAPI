using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim("email", email),
                new Claim("role", role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key_for_user"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "authapi",
                audience: "customerapi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(response);
        }
    }

}
