using Microsoft.AspNetCore.Mvc;
using NotesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        ApplicationContext db;

        public NoteController(ApplicationContext context)
        {
            db = context;
            if (!db.NotesManager.Any())
            {
                db.NotesManager.Add(new Note { Description = "do test ", NoteText = "do all points my test " });
                db.NotesManager.Add(new Note { Description = "go to shop", NoteText = "go to shop for buy eat" });
                db.NotesManager.Add(new Note { Description = "ticket", NoteText = "buy two ticket on the concert" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return db.NotesManager.ToList();
        }

        [HttpGet("{id}")]
        public Note Get(int id)
        {
            Note note = db.NotesManager.FirstOrDefault(x => x.Id == id);
            return note;
        }


        [HttpPost]
        public IActionResult Post(Note note)
        {
            if (ModelState.IsValid)
            {
                db.NotesManager.Add(note);
                db.SaveChanges();
                return Ok(note);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Update(note);
                db.SaveChanges();
                return Ok(note);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Note note = db.NotesManager.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                db.NotesManager.Remove(note);
                db.SaveChanges();
            }
            return Ok(note);
        }

    }
}
