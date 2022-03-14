using NUnit.Framework;
using RXCrud.Api.Security;
using RXCrud.Domain.Dto;
using System.Collections.Generic;

namespace RXCrud.NUnitTest.Security
{
    public class AccessTokenTest
    {
        [Test]
        public void GenerateToken()
        {
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.Senha = "123";
            usuarioDto.Nome = "TesteToken";
            usuarioDto.NomeAcesso = "testetoken";
            usuarioDto.Email = "testetoken@teste.com.br";

            IList<string> permissoes = new List<string>();
            permissoes.Add("authenticated_api");

            Assert.IsNotEmpty(AccessToken.GenerateToken(usuarioDto));
        }
    }
}