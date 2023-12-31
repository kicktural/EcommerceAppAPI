﻿using Core.DataAccess.EntityFremawork;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EFRepositoryBase<TEntity, TContext> : IRepostoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new() 
    {

        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addentity = context.Entry(entity);
            addentity.State = EntityState.Added;
            context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var DeleteEntity = context.Entry(entity);
            DeleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(expression);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            using var context = new TContext();
            return expression == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(expression).ToList();

        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var UpdateEntity = context.Entry(entity);
            UpdateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

