using FlightScheduleApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //--- Retorna uma lista de produtos por fornecedor
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        
        //--- Lista de produtos e fornecedores do produto
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        
        //--- Retorna um produto e o fornecedor
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
