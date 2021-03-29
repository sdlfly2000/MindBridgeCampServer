using Domain.Note;

namespace Domain.Services.Note.Gateways
{
    public interface INoteGateway
    {
        INote Load(string noteId);
    }
}
