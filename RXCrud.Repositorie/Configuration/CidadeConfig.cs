using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RXCrud.Domain.Entities;

namespace RXCrud.Data.Configuration
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.IdEstado).IsRequired();
            builder.HasOne(c => c.Estado).WithMany(c => c.Cidades).HasForeignKey(c => c.IdEstado).OnDelete(DeleteBehavior.Restrict);
        }
    }
}