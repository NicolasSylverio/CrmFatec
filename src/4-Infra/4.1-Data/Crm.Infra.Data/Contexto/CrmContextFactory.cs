using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crm.Infra.Data.Contexto
{
    public class CrmContextFactory : IDesignTimeDbContextFactory<CrmContext>
    {
        public CrmContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CrmContext>();
            optionsBuilder.UseSqlServer("Server=NICOLASPC;Database=Crm;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CrmContext(optionsBuilder.Options);
        }
    }
}
