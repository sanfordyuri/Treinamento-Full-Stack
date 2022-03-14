using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RXCrud.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        void Criar(TModel model);

        void Atualizar(TModel model);

        void Remover(TModel model);

        void RemoverLista(IList<TModel> models);

        IQueryable<TModel> ObterTodos();

        TModel PesquisarPor(Expression<Func<TModel, bool>> predicate);

        TModel PesquisarPorId(Guid id);

        IQueryable<TModel> ObterTodosPor(Expression<Func<TModel, bool>> predicate);
    }
}