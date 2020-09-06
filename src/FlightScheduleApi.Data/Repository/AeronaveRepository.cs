using FlightScheduleApi.Business.Interfaces;
using FlightScheduleApi.Business.Models;
using FlightScheduleApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Data.Repository
{
    public class AeronaveRepository : Repository<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(FlightScheduleDbContext context) : base(context) { }

        public async Task<Aeronave> ObterAeronave(Guid id)
        {
            //--- Obtem a Aeronave
            return await Db.Aeronaves.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
