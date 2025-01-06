using DataAccess.Repository;

namespace AppConsole.Metodos;

public class GlobalMethods
{
    public static void LimparBanco()
    {
        var unitOfWork = new UnitOfWork();
        unitOfWork.LimparBanco();
    }
}