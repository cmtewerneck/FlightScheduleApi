using FlightScheduleApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface IFornecedorServices : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);
    }
}
