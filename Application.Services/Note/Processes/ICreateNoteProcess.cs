using Application.Note;

namespace Application.Services.Note.Processes
{
    public interface ICreateNoteProcess
    {
        void Create(string loginToken, NoteModel model);
    }
}
