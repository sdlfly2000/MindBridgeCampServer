using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.LearningRoom.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    [ServiceLocate(typeof(ISignInAspectLoader))]
    public class SignInAspectLoader : ISignInAspectLoader
    {
        private readonly ISignInAspectMapper _signInAspectMapper;
        private readonly ISignInRepository _signInRepository;

        public SignInAspectLoader(
            ISignInAspectMapper signInAspectMapper,
            ISignInRepository signInRepository)
        {
            _signInAspectMapper = signInAspectMapper;
            _signInRepository = signInRepository;
        }

        public IList<ISignInAspect> Load(RoomReference reference)
        {
            var signInEntities = _signInRepository.FindByRoom(reference.Code);
            return signInEntities.Select(s => _signInAspectMapper.Map(s)).ToList();
        }

        public ISignInAspect Load(SignInReference reference)
        {
            return _signInAspectMapper.Map(_signInRepository.FindById(reference.Code));
        }
    }
}
