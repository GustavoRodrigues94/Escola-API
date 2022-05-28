using System.Threading.Tasks;

namespace Escola.Core.Comandos.Contratos
{
    public interface IComandoManipulador<in T> where T : IComando
    {
        Task<ComandoResultado> Manipular(T comando);
    }
}
