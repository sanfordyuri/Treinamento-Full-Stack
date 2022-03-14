using AutoMapper;
using Moq;
using NUnit.Framework;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace RXCrud.NUnitTest.Services
{
    public class UsuarioServiceTest
    {
        private IMapper _mapper;
        private Usuario _usuario;
        private IUsuarioService _usuarioService;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;

        public UsuarioServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_mapper, _mockUsuarioRepository.Object);
            _usuario = new Usuario("Usuario Teste", "testeusuario@teste.com", "testeusuario", "123");
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new UsuarioDto());

        [Test]
        public void CriarTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcessoSenha("testecreatesemperfil", "123")).Returns(_usuario);
            Assert.DoesNotThrow(() => _usuarioService.Criar(new UsuarioDto("Usuario Teste Criar Sem Perfil", "testecreatesemperfil@teste.com",
                "testecreatesemperfil", "123")));
        }

        [Test]
        public void CriarComNomeAcessoJaCadastradoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcesso(_usuario.NomeAcesso)).Returns(_usuario);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _usuarioService.Criar(new UsuarioDto("Usuario Teste", "testeusuariocomnomeacesso@teste.com", "testeusuario", "123")))
                .Message.Equals("O usuário informado já está sendo utilizado."));
        }

        [Test]
        public void CriarComEmailJaCadastradoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorEmail(_usuario.Email)).Returns(_usuario);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _usuarioService.Criar(new UsuarioDto("Usuario Teste", "testeusuario@teste.com", "testeusuario", "123")))
                .Message.Equals("O e-mail informado já está sendo utilizado."));
        }

        [Test]
        public void AtualizarTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcessoSenha("testeupdatesemperfil", "123")).Returns(_usuario);
            Assert.DoesNotThrow(() => _usuarioService.Atualizar(new UsuarioDto("Usuario Teste Atualizar Sem Perfil", "testeupdatesemperfil@teste.com",
                "testeupdatesemperfil", "132")));
        }

        [Test]
        public void AtualizarComNomeAcessoJaCadastradoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcesso(_usuario.NomeAcesso)).Returns(_usuario);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _usuarioService.Atualizar(new UsuarioDto("Usuario Teste", "testeusuariocomnomeacesso@teste.com", "testeusuario", "123")))
                .Message.Equals("O usuário informado já está sendo utilizado."));
        }

        [Test]
        public void AtualizarComNomeAcessoJaCadastradoSemExcecaoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcesso(_usuario.NomeAcesso)).Returns(_usuario);
            Assert.DoesNotThrow(() => _usuarioService.Atualizar(_mapper.Map<UsuarioDto>(_usuario)));
        }

        [Test]
        public void AtualizarComEmailJaCadastradoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorEmail(_usuario.Email)).Returns(_usuario);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _usuarioService.Atualizar(new UsuarioDto("Usuario Teste", "testeusuario@teste.com", "testeusuario", "123")))
                .Message.Equals("O e-mail informado já está sendo utilizado."));
        }

        [Test]
        public void AtualizarComEmailJaCadastradoSemExcecaoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorEmail(_usuario.Email)).Returns(_usuario);
            Assert.DoesNotThrow(() => _usuarioService.Atualizar(_mapper.Map<UsuarioDto>(_usuario)));
        }

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _usuarioService.Remover(new UsuarioDto("Usuario Teste Remove", "testeremove@teste.com",
                "testeremove", "123")));

        [Test]
        public void ObterTodosTest()
        {
            IList<Usuario> usuariosList = new List<Usuario>();
            usuariosList.Add(_usuario);

            _mockUsuarioRepository.Setup(r => r.ObterTodos()).Returns(usuariosList.AsQueryable());
            Assert.IsNotNull(_usuarioService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorId(_usuario.Id)).Returns(_usuario);
            Assert.IsNotNull(_usuarioService.PesquisarPorId(_usuario.Id));
        }

        [Test]
        public void PesquisarPorNomeAcessoSenhaUsuarioNaoLocalizadoTest()
        {
            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcessoSenha(_usuario.NomeAcesso, _usuario.Senha)).Returns(_usuario);

            LoginDto loginDto = new LoginDto();
            loginDto.Usuario = "teste";
            loginDto.Senha = "123";

            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _usuarioService.PesquisarPorNomeAcessoSenha(loginDto.Usuario, loginDto.Senha))
                .Message.Equals("Usuário não localizado."));
        }

        [Test]
        public void PesquisarPorNomeAcessoSenhaTest()
        {
            Usuario usuario = new Usuario("Usuario Teste", "testeusuario@teste.com", "testeusuario", "123");

            _mockUsuarioRepository.Setup(r => r.PesquisarPorNomeAcessoSenha(usuario.NomeAcesso, usuario.Senha)).Returns(usuario);

            LoginDto loginDto = new LoginDto();
            loginDto.Senha = usuario.Senha;
            loginDto.Usuario = usuario.NomeAcesso;

            Assert.IsNotNull(_usuarioService.PesquisarPorNomeAcessoSenha(loginDto.Usuario, loginDto.Senha));
        }
    }
}