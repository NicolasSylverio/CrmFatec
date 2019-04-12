using Crm.Domain.Enum;
using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Celular)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.TipoUsuario)
                .HasConversion<TipoUsuario>()
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasConversion<TipoSexo>()
                .IsRequired();


            builder.Property(x => x.IsDeleted)                
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}