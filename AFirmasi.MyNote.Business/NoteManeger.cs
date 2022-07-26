using System.Linq.Expressions;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;

namespace AFirmasi.MyNotes.Business
{
    public class NoteManeger : INoteService
    {   
        INoteRepository repo;

        public NoteManeger(INoteRepository repo)
        {
            this.repo=repo;
        }

        public void Add(Note Entity)
        {
            repo.Add(Entity);
        }

        public void Delete(Note Entity)
        {
            repo.Delete(Entity);
        }

        public List<Note> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Note GetById(int id)
        {
            return repo.GetById(id);
        }

        public List<Note> GetEx(Expression<Func<Note, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(Note Entity)
        {
            repo.Update(Entity);
        }
    }
}
