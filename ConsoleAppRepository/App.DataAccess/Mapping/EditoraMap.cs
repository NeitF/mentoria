using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mapping;

public class EditoraMap : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        builder.ToTable("EDITORA");

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("NOME")
            .IsRequired();
    }
}