using App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Core.Mapping;

public class AutorMap : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Nome)
            .HasColumnName("NOME")
            .IsRequired()
            .HasMaxLength(100);
    }
}