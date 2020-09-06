using FlightScheduleApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface IAeronaveRepository : IRepository<Aeronave>
    {
        //--- Retorna a aeronave
        Task<Aeronave> ObterAeronave(Guid id);
    }
}
