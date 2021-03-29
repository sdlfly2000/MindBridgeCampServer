using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Note.Repositories;

namespace Domain.Services.Note.Gateways.Loaders
{
    [ServiceLocate(typeof(INoteAspectLoader))]
    public class NoteAspectLoader : INoteAspectLoader
    {
        private readonly INoteRepository _noteRespository;
        private readonly INoteAspectMapper _aspectMapper;

        public NoteAspectLoader(
            INoteRepository noteRespository,
            INoteAspectMapper aspectMapper)
        {
            _noteRespository = noteRespository;
            _aspectMapper = aspectMapper;
        }

        public INoteAspect Load(NoteReference note)
        {
            return _aspectMapper.Map(_noteRespository.FindById(note.Code));
        }
    }
}
