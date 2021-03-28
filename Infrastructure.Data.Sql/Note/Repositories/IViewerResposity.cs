using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    public interface IViewerResposity
    {
        ViewerEntity FindById(string id);

        IList<ViewerEntity> FindByNote(string noteId); 
    }
}
