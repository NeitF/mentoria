namespace DataAccess.Domain;

public class Livro
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public Guid AutorId { get; set; }
    public Guid EditoraId { get; set; }
    
    public Autor? Autor { get; set; }
    public Editora? Editora { get; set; }
}