using FlightScheduleApi.Business.Models;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        //--- Retorna o fornecedor
        Task<Fornecedor> ObterFornecedor(Guid id);

        //--- Retorna o fornecedor e a lista de produtos
        Task<Fornecedor> ObterFornecedorProdutos(Guid id);
    }
}
