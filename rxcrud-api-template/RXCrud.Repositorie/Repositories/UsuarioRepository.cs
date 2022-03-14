using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using System.Linq;

namespace RXCrud.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RXCrudContext context) : base(context)
        {
        }

        public Usuario PesquisarPorNomeAcessoSenha(string nomeAcesso, string senha)
            => _context.Set<Usuario>().Where(u => u.NomeAcesso.ToUpper().Equals(nomeAcesso.ToUpper()) && u.Senha.ToUpper().Equals(senha.ToUpper()))
            .AsNoTracking().FirstOrDefault();

        public Usuario PesquisarPorNomeAcesso(string nomeAcesso)
            => _context.Set<Usuario>().Where(u => u.NomeAcesso.ToUpper().Equals(nomeAcesso.ToUpper())).AsNoTracking().FirstOrDefault();

        public Usuario PesquisarPorEmail(string email)
            => _context.Set<Usuario>().Where(u => u.Email.ToUpper().Equals(email.ToUpper())).AsNoTracking().FirstOrDefault();
    }
}