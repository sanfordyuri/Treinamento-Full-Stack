using System;
using System.Linq;

namespace RXCrud.Domain.Interfaces.Common
{
    public interface IService<TModel>
    {
        void Criar(TModel model);

        void Atualizar(TModel model);

        void Remover(TModel model);

        IQueryable<TModel> ObterTodos();

        TModel PesquisarPorId(Guid id);
    }
}