using DataAccess.Domain;
using DataAccess.Repository;

namespace BusinessLogic.AutorBll;

public class AutorBusinessLogic : IDisposable
{
    private readonly UnitOfWork _unitOfWork;

    public AutorBusinessLogic(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AutorBusinessLogic()
    {
        _unitOfWork = new UnitOfWork();
    }

    public IEnumerable<Autor> GetAutores()
    {
        return _unitOfWork.AutorRepository.Get();
    }

    public void AddAutor(Autor autor)
    {
        _unitOfWork.AutorRepository.Add(autor);
        _unitOfWork.Commit(); 
    }

    public void DeleteAutor(Autor autor)
    {
        _unitOfWork.AutorRepository.Delete(autor);
        _unitOfWork.Commit();
    }

    public void UpdateAutor(Autor autor)
    {
        _unitOfWork.AutorRepository.Update(autor);
        _unitOfWork.Commit();
    }

    public Autor GetAutorById(Guid autorId)
    {
        return _unitOfWork.AutorRepository.GetById(x => x.Id == autorId);
    }

    public Autor GetAutorByName(string autorName)
    {
        return _unitOfWork.AutorRepository.GetAutorPorNome(autorName);
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}