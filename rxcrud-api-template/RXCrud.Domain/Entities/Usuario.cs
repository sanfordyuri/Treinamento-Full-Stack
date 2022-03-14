using System;

namespace RXCrud.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(Guid id, string nome, string email, string nomeAcesso, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            NomeAcesso = nomeAcesso;
        }

        public Usuario(string nome, string email, string nomeAcesso, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            NomeAcesso = nomeAcesso;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string NomeAcesso { get; set; }

        public string Senha { get; set; }
    }
}