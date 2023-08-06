using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infra.Data.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x=>x.Name).HasColumnName("Nome").HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("SobreNome").HasMaxLength(255).IsRequired(false);
            builder.Property(x=>x.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("DataNascimento").IsRequired();
            builder.Property(x => x.ScholarityId).HasColumnName("EscolaridadeId").IsRequired(false);
            builder.Property(x => x.SchoolHistoryId).HasColumnName("HistoricoEscolarId").IsRequired(false);

            builder.HasOne(x => x.Scholarity)
                .WithMany()
                .HasForeignKey(x => x.ScholarityId)
                .IsRequired(false);

            builder.HasOne(x => x.SchoolHistory)
                .WithMany()
                .HasForeignKey(x => x.SchoolHistoryId)
                .IsRequired(false);
        }

    }
}
