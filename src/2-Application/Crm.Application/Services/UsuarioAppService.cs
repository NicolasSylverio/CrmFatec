using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.ViewModels;
using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            var cadastroComando = _mapper.Map<Usuario>(usuarioViewModel);

            _usuarioRepository.Add(cadastroComando);
        }

        public IEnumerable<UsuarioViewModel> GetAllUsuarioViewModel()
        {
            var usuarios = _usuarioRepository.GetAll().ToList();

            var usuariosViewModel = new List<UsuarioViewModel>();

            foreach (var usuario in usuarios)
            {
                usuariosViewModel.Add(_mapper.Map<UsuarioViewModel>(usuario));
            }

            return usuariosViewModel;
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}