using AFirmasi.MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetEx(Expression<Func<Category, bool>> predicate);
        Category GetById(int id);
        void Add(Category Entity);
        void Delete(Category Entity);
        void Update(Category Entity);
    }
}
