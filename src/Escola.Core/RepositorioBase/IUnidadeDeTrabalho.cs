using System.Threading.Tasks;

namespace Escola.Core.RepositorioBase
{
    public interface IUnidadeDeTrabalho
    {
        Task<bool> Commit();
    }
}
