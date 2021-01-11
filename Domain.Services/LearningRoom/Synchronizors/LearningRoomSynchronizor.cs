using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors.Persistors;
using Infrastructure.Data.Sql.Persistence;
using System.Linq;

namespace Domain.Services.LearningRoom.Synchronizors
{
    [ServiceLocate(typeof(ILearningRoomSynchronizor))]
    public class LearningRoomSynchronizor : ILearningRoomSynchronizor
    {
        private readonly IRoomPersistor _roomPersistor;
        private readonly IParticipantPersistor _participantPersistor;
        private readonly IPersistence _persistence;
        private readonly ILearningRoomGateway _learningRoomGateway;

        public LearningRoomSynchronizor(
            ILearningRoomGateway learningRoomGateway,
            IRoomPersistor roomPersistor,
            IParticipantPersistor participantPersistor,
            IPersistence persistence)
        {
            _roomPersistor = roomPersistor;
            _persistence = persistence;
            _learningRoomGateway = learningRoomGateway;
            _participantPersistor = participantPersistor;
        }

        public void Add(ILearningRoom learningRoom)
        {
            _roomPersistor.Add(learningRoom);
            learningRoom.Participants.ToList().ForEach(p => _participantPersistor.Add(p));
            _persistence.Complete();
        }

        public void Update(ILearningRoom learningRoom)
        {
            _roomPersistor.Update(learningRoom);

            var participantCodesExist = _learningRoomGateway.Load(learningRoom.Reference).Participants.Select(p => p.Reference.Code);

            var participantsToAdd = learningRoom.Participants.Where(p => !participantCodesExist.Contains(p.Reference.Code)).ToList();
            var participantsToUpdate = learningRoom.Participants.Where(p => participantCodesExist.Contains(p.Reference.Code)).ToList();

            participantsToUpdate.ForEach(p => _participantPersistor.Update(p));
            participantsToAdd.ForEach(p => _participantPersistor.Add(p));

            _persistence.Complete();
        }
    }
}
