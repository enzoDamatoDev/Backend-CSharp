using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(u => u.descricao)
                .HasMaxLength(400)
                .IsRequired();
            builder.Property(u => u.UrlFoto).IsRequired();
            builder.HasMany(u => u.postagens).WithOne(p => p.Grupo);
            
        }
    }
}
