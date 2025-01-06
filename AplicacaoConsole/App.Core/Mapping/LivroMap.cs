using App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Core.Mapping;

public class LivroMap : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Titulo)
            .HasColumnName("TITULO")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.AnoPublicacao)
            .HasColumnName("ANO_PUBLICACAO")
            .IsRequired();

        builder.Property(x => x.AutorId)
            .HasColumnName("AUTOR_ID")
            .IsRequired();
        
        builder.Property(x => x.EditoraId)
            .HasColumnName("EDITORA_ID")
            .IsRequired();

        builder.HasOne(x => x.Autor)
            .WithMany(x => x.Livros)
            .HasForeignKey(x => x.AutorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Editora)
            .WithMany(x => x.Livros)
            .HasForeignKey(x => x.EditoraId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}