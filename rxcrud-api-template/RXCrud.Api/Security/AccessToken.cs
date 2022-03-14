using Microsoft.IdentityModel.Tokens;
using RXCrud.Api.Configuracoes;
using RXCrud.Domain.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RXCrud.Api.Security
{
    public static class AccessToken
    {
        public static string GenerateToken(UsuarioDto usuarioDto)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(TokenConfig.SecretKey);

            IList<Claim> claim = new List<Claim>();
            claim.Add(new Claim("id", usuarioDto.Id.ToString()));
            claim.Add(new Claim(ClaimTypes.Name, usuarioDto.Nome.ToString()));
            claim.Add(new Claim(ClaimTypes.Email, usuarioDto.Email.ToString()));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddHours(TokenConfig.ExpireTimeInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}