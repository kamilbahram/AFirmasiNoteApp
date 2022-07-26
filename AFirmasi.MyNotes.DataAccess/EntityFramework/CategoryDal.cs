using AFirmasi.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class CategoryDal : RepositoryBase<Category, MyNotesDbContext>, ICategoryRepository
    {
        public CategoryDal(MyNotesDbContext context) : base(context)
        {
        }
    }
 }
