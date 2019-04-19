using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Models;
using Crm.Infra.Data.Contexto;

namespace Crm.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CrmContext context) : base(context)
        {
        }

        public Usuario GetByLogin(string login)
        {
            return new Usuario();
        }
    }
}