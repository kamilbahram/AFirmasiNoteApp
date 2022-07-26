using AFirmasi.MyNotes.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class SeedDataBase
    {
        public static void initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MyNotesDbContext>();
              
            Category category = new Category
            {
                CategoryName = "Sosyall Ağlar"
            };

            if (!context.Categories.Any())
            {
                context.Categories.Add(category);
                if (context.SaveChanges() > 0)
                {
                    Note note = new Note
                    {
                        NoteTitle = "Ağlar",
                        Description = "Ağlar aıklaması",
                        CategoryID = category.Id,
                        Category = category
                    };
                    context.Notes.Add(note);
                    context.SaveChanges();
                }
            }
            
        }

        public static void initialize(object applicationServices)
        {
            throw new NotImplementedException();
        }
    }
}
