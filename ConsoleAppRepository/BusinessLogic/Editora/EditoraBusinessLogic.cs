using DataAccess.Domain;
using DataAccess.Repository;

namespace BusinessLogic.EditoraBll;

public class EditoraBusinessLogic : IDisposable
{
    private readonly UnitOfWork _unitOfWork;

    public EditoraBusinessLogic(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public EditoraBusinessLogic()
    {
        _unitOfWork = new UnitOfWork();
    }
    
    public IEnumerable<Editora> GetEditoras()
    {
        return _unitOfWork.EditoraRepository.Get();
    }

    public void AddEditora(Editora editora)
    {
        _unitOfWork.EditoraRepository.Add(editora);
        _unitOfWork.Commit(); 
    }

    public void DeleteEditora(Editora editora)
    {
        _unitOfWork.EditoraRepository.Delete(editora);
        _unitOfWork.Commit();
    }

    public void UpdateEditora(Editora editora)
    {
        _unitOfWork.EditoraRepository.Update(editora);
        _unitOfWork.Commit();
    }

    public Editora GetEditoraById(Guid editoraId)
    {
        return _unitOfWork.EditoraRepository.GetById(x => x.Id == editoraId);
    }

    public Editora GetEditoraByName(string editoraName)
    {
        return _unitOfWork.EditoraRepository.GetEditoraPorNome(editoraName);
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}