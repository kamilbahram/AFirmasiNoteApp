
using AFirmasi.Core.Entities;

namespace AFirmasi.MyNotes.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } 

        public List<Note> Notes { get; set; } 
    }
}
