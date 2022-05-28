using System;
using Escola.Application.Comandos.Contratos;
using Escola.Core.Comandos.Contratos;
using Flunt.Notifications;

namespace Escola.Application.Comandos
{
    public class DeletarAlunoComando : Notifiable<Notification>, IComando
    {
        public DeletarAlunoComando(Guid alunoId)
        {
            AlunoId = alunoId;

            AddNotifications(new DeletarAlunoContrato(this));
        }

        public Guid AlunoId { get; private set; }
    }
}
