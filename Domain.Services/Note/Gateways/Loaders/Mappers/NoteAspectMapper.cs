using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.Note;
using Domain.User;
using Infrastructure.Data.Sql.Note.Entities;
using System.Linq;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(INoteAspectMapper))]
    public class NoteAspectMapper : INoteAspectMapper
    {
        public INoteAspect Map(NoteEntity entity)
        {
            return new NoteAspect
            {
                Reference = new NoteReference(entity.noteId),
                Title = entity.title,
                Content = entity.content,
                CreatedBy = new UserReference(entity.createdBy),
                CreatedOn = entity.createdOn
            };
        }
    }
}
