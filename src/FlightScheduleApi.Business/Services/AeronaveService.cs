using FlightScheduleApi.Business.Interfaces;
using FlightScheduleApi.Business.Models;
using FlightScheduleApi.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Services
{
    public class AeronaveService : BaseService, IAeronaveServices
    {
        private readonly IAeronaveRepository _aeronaveRepository;

        public AeronaveService(IAeronaveRepository aeronaveRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _aeronaveRepository = aeronaveRepository;
        }


        public async Task<bool> Adicionar(Aeronave aeronave)
        {
            if (!ExecutarValidacao(new AeronaveValidation(), aeronave)) return false;

            if (_aeronaveRepository.Buscar(f => f.Matricula == aeronave.Matricula).Result.Any())
            {
                Notificar("Já existe uma aeronave com esta matrícula.");
                return false;
            }

            await _aeronaveRepository.Adicionar(aeronave);
            return true;
        }

        public async Task<bool> Atualizar(Aeronave aeronave)
        {
            if (!ExecutarValidacao(new AeronaveValidation(), aeronave)) return false;

            if (_aeronaveRepository.Buscar(f => f.Matricula == aeronave.Matricula && f.Id != aeronave.Id).Result.Any())
            {
                Notificar("Já existe uma aeronave com esta matrícula.");
                return false;
            }

            await _aeronaveRepository.Atualizar(aeronave);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _aeronaveRepository.Remover(id);
            return true;
        }
        
        public void Dispose()
        {
            _aeronaveRepository?.Dispose();
        }
    }
}
