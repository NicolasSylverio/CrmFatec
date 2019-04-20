using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Models;
using Crm.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly CrmContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(CrmContext context)
        {
            Db = context;
        }

        public void Add(Usuario obj)
        {
            Db.Set<Usuario>().Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Db.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return Db.Set<Usuario>().Find(id);
        }

        public Usuario GetByLogin(string login)
        {
            return new Usuario();
        }

        public void Remove(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new System.NotImplementedException();
        }
    }
}