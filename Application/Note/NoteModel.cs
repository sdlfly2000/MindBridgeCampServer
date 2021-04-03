using System.Collections.Generic;

namespace Application.Note
{
    public class NoteModel
    {
        public NoteModel()
        {
            Tags = new List<string>();
            Images = new List<string>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> Images { get; set; }
    }
}
