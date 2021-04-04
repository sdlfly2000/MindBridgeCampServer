using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Note
{
    public class NoteModel
    {
        public NoteModel()
        {
            Tags = new List<string>();
            Images = new List<string>();
        }

        public string NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [DataMember(IsRequired = false)]
        public IList<string> Tags { get; set; }

        [DataMember(IsRequired = false)]
        public IList<string> Images { get; set; }
    }
}
