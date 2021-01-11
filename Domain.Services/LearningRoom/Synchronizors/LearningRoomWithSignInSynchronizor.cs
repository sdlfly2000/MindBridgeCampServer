using System.Linq;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors.Persistors;
using Infrastructure.Data.Sql.Persistence;

namespace Domain.Services.LearningRoom.Synchronizors
{
    [ServiceLocate(typeof(ILearningRoomWithSignInSynchronizor))]
    public class LearningRoomWithSignInSynchronizor : ILearningRoomWithSignInSynchronizor
    {
        private readonly ILearningRoomWithSignInGateway _learningRoomWithSignInGateway;
        private readonly ISignInPersistor _signInPersistor;
        private readonly IPersistence _persistence;

        public LearningRoomWithSignInSynchronizor(
            ILearningRoomWithSignInGateway learningRoomWithSignInGateway,
            ISignInPersistor signInPersistor,
            IPersistence persistence)
        {
            _learningRoomWithSignInGateway = learningRoomWithSignInGateway;
            _signInPersistor = signInPersistor;
            _persistence = persistence;
        }

        public void Update(ILearningRoomWithSignIn learningRoom)
        {
            var learningRoomsWithSignIn = _learningRoomWithSignInGateway.Load(learningRoom.Reference);
            var signInsAdded = learningRoom.SignIns
                .Where(signIn => learningRoomsWithSignIn.SignIns.All(s => !s.Reference.Equals(signIn.Reference)))
                .ToList();
            
            signInsAdded.ForEach(s => _signInPersistor.Add(s));
            _persistence.Complete();
        }
    }
}