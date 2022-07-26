using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;

namespace AFirmasi.MyNotes.Business
{
    public class CategoryManeger : ICategoryService
    {
        ICategoryRepository repo;  //data access katmanınına ulaşıyoruz
        //Busines katmanından data access katmanına ulaşmış oluyoruz.
        public CategoryManeger(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Category Entity)
        {
            repo.Add(Entity);
        }

        public void Delete(Category Entity)
        {
            repo.Delete(Entity);
        }

        public List<Category> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return repo.GetById(id);
        }

        public List<Category> GetEx(Expression<Func<Category, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(Category Entity)
        {
            repo.Update(Entity);    
        }
    }
}
