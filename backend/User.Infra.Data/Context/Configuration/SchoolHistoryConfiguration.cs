using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infra.Data.Context.Configuration
{
    public class SchoolHistoryConfiguration : IEntityTypeConfiguration<SchoolHistory>
    {
        public void Configure(EntityTypeBuilder<SchoolHistory> builder)
        {
            builder.ToTable("HistoricoEscolar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Format).HasColumnName("Formato").HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Name).HasColumnName("Nome").HasMaxLength(255).IsRequired();
            builder.Property(x => x.FileBase64).HasColumnName("ArquivoBase64").HasColumnType("text").IsRequired(false);
        }
    }
}
