using Domain.Note;

namespace Domain.Services.Note.Persistors
{
    public interface INotePersistor
    {
        void Persist(INote note);
    }
}
