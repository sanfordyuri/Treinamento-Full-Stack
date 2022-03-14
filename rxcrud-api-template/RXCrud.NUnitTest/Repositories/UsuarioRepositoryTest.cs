using NUnit.Framework;
using RXCrud.Data.Repositories;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.NUnitTest.Common;
using System;
using System.Collections.Generic;

namespace RXCrud.NUnitTest.Repositories
{
    public class UsuarioRepositoryTest
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioRepositoryTest()
            => _usuarioRepository = new UsuarioRepository(Utilitarios.GetContext());

        [Test]
        public void CriarTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste Create", "testecreate@teste.com", "testecreate", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPorId(usuario.Id));
        }

        [Test]
        public void AtualizarTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste Update", "testeupdateusuario@teste.com", "testeupdateusuario", "123");
            _usuarioRepository.Criar(usuario);

            usuario.Nome = "Usuário Atualizado";
            _usuarioRepository.Atualizar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPor(x => x.Nome.Equals("Usuário Atualizado")));
        }

        [Test]
        public void RemoverTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste Remove", "testeremove@teste.com", "testeremove", "123");
            _usuarioRepository.Criar(usuario);

            _usuarioRepository.Remover(usuario);

            Assert.IsNull(_usuarioRepository.PesquisarPorId(usuario.Id));
        }

        [Test]
        public void RemoverListaTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste Remove Range", "testeremoverange@teste.com", "testeremoverange", "123");
            _usuarioRepository.Criar(usuario);

            IList<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(usuario);

            _usuarioRepository.RemoverLista(usuarios);

            Assert.IsNull(_usuarioRepository.PesquisarPorId(usuario.Id));
        }

        [Test]
        public void ObterTodosTest()
            => Assert.IsNotNull(_usuarioRepository.ObterTodos());

        [Test]
        public void PesquisarPorTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste PesquisarPor", "testefindby@teste.com", "testefindby", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPor(x => x.Id.Equals(usuario.Id)));
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste PesquisarPorId", "testefindbyid@teste.com", "testefindbyid", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPorId(usuario.Id));
        }

        [Test]
        public void ObterTodosPorTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste ObterTodosPor", "testefindallby@teste.com", "testefindallby", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.ObterTodosPor(x => x.Id.Equals(usuario.Id)));
        }

        [Test]
        public void PesquisarPorNomeAcessoSenhaTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste PesquisarPorNomeSenhaTest", "testefindbynomesenha@teste.com", "testefindbynomesenha", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPorNomeAcessoSenha(usuario.NomeAcesso, usuario.Senha));
        }

        [Test]
        public void PesquisarPorNomeAcessoTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste PesquisarPorNomeAcesso", "testefindbynomeacesso@teste.com", "testefindbynomeacesso", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPorNomeAcesso(usuario.NomeAcesso));
        }

        [Test]
        public void PesquisarPorEmailTest()
        {
            Usuario usuario = new Usuario(Guid.NewGuid(), "Usuário Teste PesquisarPorEmail", "testefindbyemail@teste.com", "testefindbyemail", "123");
            _usuarioRepository.Criar(usuario);

            Assert.IsNotNull(_usuarioRepository.PesquisarPorEmail(usuario.Email));
        }
    }
}