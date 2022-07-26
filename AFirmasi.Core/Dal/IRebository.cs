using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AFirmasi.Core.Entities;

namespace AFirmasi.Core.Dal
{
    public interface IRebository<T> where T : IEntity      // tip class olarak tanımlayamadım.  
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetEx(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
        int Save(); 
    }
}
