using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id)
                .HasColumnName("UserId");

            entity.Property(e => e.Email).IsUnicode(false);

            entity.Property(e => e.Image).IsUnicode(false);

            entity.Property(e => e.Password).IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
