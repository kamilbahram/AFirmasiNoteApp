using AFirmasi.MyNotes.Entities;
using System.Linq.Expressions;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface INoteService
    {
        List<Note> GetAll();
        List<Note> GetEx(Expression<Func<Note, bool>> predicate);
        Note GetById(int id);
        void Add(Note Entity);
        void Delete(Note Entity);
        void Update(Note Entity);
    }
}
