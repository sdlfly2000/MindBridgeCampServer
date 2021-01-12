using Common.Core.DependencyInjection;
using Core;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.Services.LoginToken;
using System;
using System.Linq;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(ISignInRoomProcess))]
    public class SignInRoomProcess : ISignInRoomProcess
    {
        private readonly ILearningRoomWithSignInSynchronizor _learningRoomWithSignInSynchronizor;
        private readonly ILearningRoomWithSignInGateway _learningRoomWithSignInGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public SignInRoomProcess(
            ILearningRoomWithSignInSynchronizor learningRoomWithSignInSynchronizor,
            ILearningRoomWithSignInGateway learningRoomWithSignInGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _learningRoomWithSignInSynchronizor = learningRoomWithSignInSynchronizor;
            _learningRoomWithSignInGateway = learningRoomWithSignInGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public void SignIn(string loginToken, string roomId)
        {
            var user = _loginTokenGateway.Get(loginToken);
            var learningRoomWithSignIn = _learningRoomWithSignInGateway.Load(new RoomReference(roomId));

            if(learningRoomWithSignIn.SignIns.Any(s => s.Participant.Equals(user.OpenId)))
            {
                return;
            }

            learningRoomWithSignIn.SignIns.Add(new SignInAspect
            {
                Reference = new SignInReference(Guid.NewGuid().ToString()),
                Room = learningRoomWithSignIn.Reference,
                SignInOn = DateTimeUtil.GetNow(),
                Participant = user.OpenId
            });

            _learningRoomWithSignInSynchronizor.Update(learningRoomWithSignIn);
        }
    }
}
