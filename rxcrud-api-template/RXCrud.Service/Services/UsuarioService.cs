using AutoMapper;
using AutoMapper.QueryableExtensions;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace RXCrud.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public void Criar(UsuarioDto usuarioDto)
        {
            EmailJaCadastrado(usuarioDto);
            NomeAcessoJaCadastrado(usuarioDto);

            _usuarioRepository.Criar(_mapper.Map<Usuario>(usuarioDto));
            UsuarioDto usuario = PesquisarPorNomeAcessoSenha(usuarioDto.NomeAcesso, usuarioDto.Senha);
        }

        public void Atualizar(UsuarioDto usuarioDto)
        {
            EmailJaCadastrado(usuarioDto);
            NomeAcessoJaCadastrado(usuarioDto);

            _usuarioRepository.Atualizar(_mapper.Map<Usuario>(usuarioDto));
        }

        private void NomeAcessoJaCadastrado(UsuarioDto usuarioDto)
        {
            Usuario usuario = _usuarioRepository.PesquisarPorNomeAcesso(usuarioDto.NomeAcesso);
            if ((usuario != null) && (usuario.Id != usuarioDto.Id))
            {
                throw new RXCrudException("O usuário informado já está sendo utilizado.");
            }
        }

        private void EmailJaCadastrado(UsuarioDto usuarioDto)
        {
            Usuario usuario = _usuarioRepository.PesquisarPorEmail(usuarioDto.Email);
            if ((usuario != null) && (usuario.Id != usuarioDto.Id))
            {
                throw new RXCrudException("O e-mail informado já está sendo utilizado.");
            }
        }

        public void Remover(UsuarioDto usuarioDto)
            => _usuarioRepository.Remover(_mapper.Map<Usuario>(usuarioDto));

        public IQueryable<UsuarioDto> ObterTodos()
            => _usuarioRepository.ObterTodos().ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider);

        public UsuarioDto PesquisarPorId(Guid id)
            => _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorId(id));

        public UsuarioDto PesquisarPorNomeAcessoSenha(string nomeAcesso, string senha)
        {
            UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorNomeAcessoSenha(nomeAcesso, senha));

            if (usuarioDto == null)
            {
                throw new RXCrudException("Usuário não localizado.");
            }

            return usuarioDto;
        }
    }
}