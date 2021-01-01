﻿using Application.LearningRoom;

namespace Application.Services.LearningRoom.Processes
{
    public interface ICreateRoomProcess
    {
        void Create(string loginToken, LearningRoomModel model);
    }
}
