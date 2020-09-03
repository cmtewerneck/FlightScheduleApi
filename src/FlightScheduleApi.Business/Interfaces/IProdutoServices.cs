using FlightScheduleApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface IProdutoServices : IDisposable
    {
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Remover(Guid id);
    }
}
