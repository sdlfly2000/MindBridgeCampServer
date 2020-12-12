﻿using Application.Services.User.Contracts;
using Application.User;

namespace Application.Services.User
{
    public interface IUserService
    {
        GetResponse Get(GetByIdRequest request);

        GetResponse Add(UserModel model);
    }
}