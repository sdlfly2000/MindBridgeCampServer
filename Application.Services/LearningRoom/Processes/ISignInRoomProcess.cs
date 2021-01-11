namespace Application.Services.LearningRoom.Processes
{
    public interface ISignInRoomProcess
    {
        void SignIn(string loginToken, string roomId);
    }
}
