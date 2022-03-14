using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RXCrud.Data.Common
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly RXCrudContext _context;

        public Repository(RXCrudContext context)
            => _context = context;

        public void Criar(TModel model)
        {
            _context.Set<TModel>().Add(model);
            _context.SaveChanges();
        }

        public void Atualizar(TModel model)
        {
            _context.Set<TModel>().Update(model);
            _context.SaveChanges();
        }

        public void Remover(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            _context.SaveChanges();
        }

        public void RemoverLista(IList<TModel> models)
        {
            _context.Set<TModel>().RemoveRange(models);
            _context.SaveChanges();
        }

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();

        public TModel PesquisarPor(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate).AsNoTracking().FirstOrDefault();

        public TModel PesquisarPorId(Guid id)
            => PesquisarPor(t => t.Id.Equals(id));

        public IQueryable<TModel> ObterTodosPor(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate).AsNoTracking().AsQueryable();
    }
}