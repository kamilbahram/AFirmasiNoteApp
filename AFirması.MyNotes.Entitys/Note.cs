using AFirmasi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.Entities
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
