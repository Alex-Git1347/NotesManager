using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManager.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string NoteText { get; set; }
    }
}
