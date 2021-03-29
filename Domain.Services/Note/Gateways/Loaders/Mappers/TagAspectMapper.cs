using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.User;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(ITagAspectMapper))]
    public class TagAspectMapper : ITagAspectMapper
    {
        public ITagAspect Map(TagEntity entity)
        {
            return new TagAspect
            {
                Caption = entity.caption,
                CreatedBy = new UserReference(entity.createdBy),
                CreatedOn = entity.createdOn,
                Note = new NoteReference(entity.noteId),
                Reference = new TagReference(entity.tagId)
            };
        }
    }
}
