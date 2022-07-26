using System.ComponentModel.DataAnnotations;

namespace AFirmasi.MyNotes.WebapiServis.Model
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Category ismi girmek zorunludur.")]
        public string CategoryName { get; set; }
    }
}
