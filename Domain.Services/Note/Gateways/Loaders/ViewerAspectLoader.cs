using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Note.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Note.Gateways.Loaders
{
    [ServiceLocate(typeof(IViewerAspectLoader))]
    public class ViewerAspectLoader : IViewerAspectLoader
    {
        private readonly IViewerRepository _viewerRepository;
        private readonly IViewerAspectMapper _viewerAspectMapper;

        public ViewerAspectLoader(
            IViewerRepository viewerRepository,
            IViewerAspectMapper viewerAspectMapper)
        {
            _viewerRepository = viewerRepository;
            _viewerAspectMapper = viewerAspectMapper;
        }

        public IViewerAspect Load(ViewerReference viewer)
        {
            return _viewerAspectMapper.Map(_viewerRepository.FindById(viewer.Code));
        }

        public IList<IViewerAspect> LoadByNote(NoteReference note)
        {
            return _viewerRepository
                .FindByNote(note.Code)
                .Select(_viewerAspectMapper.Map)
                .ToList();
        }
    }
}
