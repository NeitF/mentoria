using App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Core.Mapping;

public class EditoraMap : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Nome)
            .HasColumnName("NOME")
            .IsRequired();
    }
}