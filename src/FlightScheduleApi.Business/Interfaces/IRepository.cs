using FlightScheduleApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightScheduleApi.Business.Interfaces
{
    //--- Interface implementa IDisposable para liberar memória e só pode ser usada por classes onde TEntity herda Entity
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        //--- Não há retorno, por isso Task apenas
        Task Adicionar(TEntity entity);
        
        //--- Há retorno de uma entidade do tipo TENtity
        Task<TEntity> ObterPorId(Guid id);

        //--- Há retorno de uma lista do tipo TEntity
        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);
        Task Remover(Guid id);

        //--- Passar uma expressão que trabalha com uma function que compara sua entidade com outra 
        // coisa retornando boolean
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        //--- Retorna número de linhas afetadas
        Task<int> SaveChanges();
    }
}
