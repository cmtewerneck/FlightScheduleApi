using FlightScheduleApi.Business.Interfaces;
using FlightScheduleApi.Business.Models;
using FlightScheduleApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FlightScheduleApi.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FlightScheduleDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedor(Guid id)
        {
            //--- Obtem o Fornecedor e o Endereço
            return await Db.Fornecedores.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutos(Guid id)
        {
            //--- Retorna o fornecedor com os produtos e com o endereço dele
            return await Db.Fornecedores.AsNoTracking()
		        .Include(c => c.Produtos)                
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
