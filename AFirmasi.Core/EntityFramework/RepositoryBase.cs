using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFirmasi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AFirmasi.Core.Dal;
using System.Linq.Expressions;

namespace AFirmasi.Core.EntityFramework
{
    public class RepositoryBase<Tentity, Tcontext> : IRebository<Tentity>
        where Tentity : IEntity          // tip şeklini class tanımlayamadım
        where Tcontext : DbContext
    {
        protected readonly Tcontext context;

        public RepositoryBase(Tcontext context)
        {
            this.context = context;
        }

        public void Add(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
            Save();
        }

        public void Delete(Tentity Entity)
        {
            context.Set<Tentity>().Remove(Entity);
            Save();
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }

        public Tentity GetById(int id)
        {
            return context.Set<Tentity>().Find(id);
        }

        public IQueryable<Tentity> GetEx(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Tentity Entity)
        {
            context.Set<Tentity>().Update(Entity);
            Save();
        }
    }
}
