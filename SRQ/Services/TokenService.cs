using Microsoft.IdentityModel.Tokens;
using API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    internal class TokenService
    {
        public string GenerateToken(UsuarioModel usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("Email", usuario.UsuarioEmail),
                new Claim("Id",usuario.UsuarioId.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("API-API"));
            
            var signInCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddDays(1),
                    claims: claims,
                    signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
