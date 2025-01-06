namespace DataAccess.Domain;

public class Autor
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Livro> Livros { get; set; } = new List<Livro>();
}