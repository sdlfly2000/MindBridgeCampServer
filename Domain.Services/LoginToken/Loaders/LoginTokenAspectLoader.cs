﻿using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Domain.Services.LoginToken.Loaders.Mappers;
using Infrastructure.Data.CacheAgent.LoginToken.Repositories;

namespace Domain.Services.LoginToken.Loaders
{
    [ServiceLocate(typeof(ILoginTokenAspectLoader))]
    public class LoginTokenAspectLoader : ILoginTokenAspectLoader
    {
        private readonly IWeixinAuthorityRepository _repository;
        private readonly ILoginTokenAspectMapper _mapper;

        public LoginTokenAspectLoader(
            IWeixinAuthorityRepository repository,
            ILoginTokenAspectMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ILoginTokenAspect Load(string accessToken)
        {
            return _mapper.Map(_repository.Find(accessToken));
        }
    }
}
