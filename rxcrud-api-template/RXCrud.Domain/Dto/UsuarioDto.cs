using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Usuario")]
    public class UsuarioDto
    {
        public UsuarioDto()
            => Id = Guid.NewGuid();

        public UsuarioDto(string nome, string email, string nomeAcesso, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            NomeAcesso = nomeAcesso;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Nome' obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'E-mail' obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Nome acesso' obrigatório.")]
        public string NomeAcesso { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' obrigatório.")]
        public string Senha { get; set; }
    }
}