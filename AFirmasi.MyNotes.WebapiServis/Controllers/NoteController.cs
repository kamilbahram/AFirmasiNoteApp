using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.WebapiServis.Model;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Filters;

namespace AFirmasi.MyNotes.WebapiServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;
        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }
        [HttpGet]
        [NoteException]
        public IActionResult Get()
        {
            ServiceResponse<Note> respose = new ServiceResponse<Note>
            {
                Entities = noteService.GetAll(),
                IsSuccessFul = true
            };
            respose.EntitiesCount = respose.Entities.Count;
            return Ok(respose);
        }
        [HttpGet("{id}")]
        [NoteException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = noteService.GetById(id),
                IsSuccessFul=true
            };
            
            return Ok(response);
        }
        [HttpPost]
        [NoteException]
        [NoteValidate]
        public IActionResult Post([FromBody]NoteModel model)
        {
            Note note = new Note 
            {
                NoteTitle = model.NoteTitle,
                Description = model.NoteDescription,
                CategoryID = model.CategoryId
            };
            noteService.Add(note);
            ServiceResponse<Note> response = new ServiceResponse<Note> 
            {
                Entity = note,
                IsSuccessFul = true
            };
            return Ok(response);
        }
        [HttpPut]
        [NoteException]
        [NoteValidate]
        public IActionResult Put(int id, [FromBody]NoteModel model)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.Errors.Add("Note bulunumadı!!!");
                return BadRequest(response);
            }
            note.NoteTitle = model.NoteTitle;
            note.Description = model.NoteDescription;
            note.CategoryID = model.CategoryId;
            noteService.Update(note);
            response.IsSuccessFul = true;
            return Ok(response);
        }
        [HttpDelete]
        [NoteException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            //defefe
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.Errors.Add("Silinicek note bulunamadı!!!");
                return BadRequest(response);
            }
            noteService.Delete(note);
            response.IsSuccessFul = true;
            return Ok(response);
        }  
    }
}
