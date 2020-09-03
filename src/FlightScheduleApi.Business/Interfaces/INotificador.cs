using FlightScheduleApi.Business.Notificacoes;
using System.Collections.Generic;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
