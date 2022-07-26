using System.ComponentModel.DataAnnotations;

namespace AFirmasi.MyNotes.WebapiServis.Model
{
    public class NoteModel
    {
        [Required(ErrorMessage ="Başlık alanı boş geçilemez.")]
        public string NoteTitle { get; set; }

        [Required(ErrorMessage = "not açıklama alanı boş geçilemez")]
        public string NoteDescription { get; set; }

        [Required(ErrorMessage = "Not ıd alanı boş geçilemez.")]
        public int CategoryId { get; set; }
    }
}
