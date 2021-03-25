using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.Entities;

namespace ReCapProject.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity> where Tentity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return filter == null ? context.Set<Tentity>().ToList() : context.Set<Tentity>().Where(filter).ToList();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter); 
            }
        }

        public Tentity Add(Tentity entity)
        {
            using (TContext context=new TContext())
            {
                var add = context.Entry(entity);
                add.State = EntityState.Added;
                context.SaveChanges();
                return entity;


            }
        }

        public Tentity Update(Tentity entity)
        {
            using (TContext context=new TContext())
            {
                var update = context.Entry(entity);
                update.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Tentity entity)
        {
            using (TContext context=new TContext())
            {
                var delete = context.Entry(entity);
                delete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
