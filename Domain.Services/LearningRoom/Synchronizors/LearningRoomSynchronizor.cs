using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors.Persistors;
using System.Linq;

namespace Domain.Services.LearningRoom.Synchronizors
{
    using Common.Core.Data.Sql;
    using Common.Core.LogService;
    using Microsoft.Extensions.Caching.Memory;
    using Newtonsoft.Json;
    using System;

    [ServiceLocate(typeof(ILearningRoomSynchronizor))]
    public class LearningRoomSynchronizor : ILearningRoomSynchronizor
    {
        private readonly IRoomPersistor _roomPersistor;
        private readonly IParticipantPersistor _participantPersistor;
        private readonly IPersistence _persistence;
        private readonly ILearningRoomGateway _learningRoomGateway;
        private readonly IMemoryCache _memoryCache;

        public LearningRoomSynchronizor(
            ILearningRoomGateway learningRoomGateway,
            IRoomPersistor roomPersistor,
            IParticipantPersistor participantPersistor,
            IPersistence persistence,
            IMemoryCache memoryCache)
        {
            _roomPersistor = roomPersistor;
            _persistence = persistence;
            _learningRoomGateway = learningRoomGateway;
            _participantPersistor = participantPersistor;
            _memoryCache = memoryCache;
        }

        public void Add(ILearningRoom learningRoom)
        {
            _roomPersistor.Add(learningRoom);
            learningRoom.Participants.ToList().ForEach(p => _participantPersistor.Add(p));
            _persistence.Complete();
        }

        public void AddParticipant(Participant participant)
        {
            _participantPersistor.Add(participant);
            _persistence.Complete();
            _memoryCache.Remove(participant.Room.CacheCode);
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
            _memoryCache.Remove(learningRoom.Reference.CacheCode);
        }
    }
}
