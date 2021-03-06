﻿using Application.Services.User.Contracts;
using Application.Services.User.Processes;
using Application.User;
using Common.Core.DependencyInjection;

namespace Application.Services.User
{
    [ServiceLocate(typeof(IUserService))]
    public class UserService : IUserService
    {
        private readonly IAddUserProcess _addUserProcess;
        private readonly IGetUserProcess _getUserProcess;
        private readonly IUpdateUserProcess _updateUserProcess;
        private readonly ICheckUserExistanceProcess _checkUserExistanceProcess;

        public UserService(
            IAddUserProcess addUserProcess,
            IGetUserProcess getUserProcess,
            IUpdateUserProcess updateUserProcess,
            ICheckUserExistanceProcess checkUserExistanceProcess)
        {
            _addUserProcess = addUserProcess;
            _getUserProcess = getUserProcess;
            _updateUserProcess = updateUserProcess;
            _checkUserExistanceProcess = checkUserExistanceProcess;
        }

        public void Add(string loginToken, UserModel model)
        {
            _addUserProcess.Add(loginToken, model);
        }

        public GetResponse Get(GetByIdRequest request)
        {
            return _getUserProcess.Get(request);
        }

        public bool IsUserExist(string loginToken)
        {
            return _checkUserExistanceProcess.IsUserExist(loginToken);
        }

        public GetResponse Get(GetByLoginTokenRequest request)
        {
            return _getUserProcess.Get(request);
        }
        
        public void UpdateUserInfo(string loginToken, UserModel model)
        {
            _updateUserProcess.UpdateUserInfo(loginToken, model);
        }

        public void UpdateUser(string loginToken, UserModel model)
        {
            _updateUserProcess.UpdateUser(loginToken, model);
        }
    }
}
