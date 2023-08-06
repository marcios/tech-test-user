using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infra.Data.Context.Configuration
{
    public class ScholarityConfiguration : IEntityTypeConfiguration<Scholarity>
    {
        public void Configure(EntityTypeBuilder<Scholarity> builder)
        {
            builder.ToTable("Escolaridade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x=>x.Description).HasColumnName("Descricao").HasMaxLength(255).IsRequired();
        }
    }
}
