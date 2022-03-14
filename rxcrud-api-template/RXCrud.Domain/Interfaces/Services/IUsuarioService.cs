using RXCrud.Domain.Dto;
using RXCrud.Domain.Interfaces.Common;

namespace RXCrud.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto>
    {
        UsuarioDto PesquisarPorNomeAcessoSenha(string nomeAcesso, string senha);
    }
}