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
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Db.Usuarios
                .ToList();
        }

        public Usuario GetById(int id)
        {
            return Db.Set<Usuario>()
                .Find(id);
        }

        public Usuario GetByLogin(string login)
        {
            return Db.Set<Usuario>()
                .Where(x => x.Login == login)
                .FirstOrDefault();
        }

        public void Remove(Usuario obj)
        {
            Db.Remove(obj);
            Db.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            Db.Update(obj);
            Db.SaveChanges();
        }
    }
}