using System;
using Escola.Core.DominioBase;

namespace Escola.Core.RepositorioBase
{
    public interface IRepositorio<T> : IDisposable where T : IRaizAgregacao 
    {
        IUnidadeDeTrabalho UnidadeDeTrabalho { get; }
    }
}
