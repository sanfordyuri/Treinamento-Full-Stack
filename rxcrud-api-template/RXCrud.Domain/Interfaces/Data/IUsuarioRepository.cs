using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Common;

namespace RXCrud.Domain.Interfaces.Data
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PesquisarPorNomeAcessoSenha(string nomeAcesso, string senha);

        Usuario PesquisarPorNomeAcesso(string nomeAcesso);

        Usuario PesquisarPorEmail(string email);
    }
}