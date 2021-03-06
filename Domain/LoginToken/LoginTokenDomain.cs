﻿using Domain.User;

namespace Domain.LoginToken
{
    public class LoginTokenDomain : ILoginToken
    {
        private readonly ILoginTokenAspect _accessTokenAspect;

        public LoginTokenDomain(ILoginTokenAspect accessTokenAspect)
        {
            _accessTokenAspect = accessTokenAspect;
        }

        public UserReference OpenId
        {
            get { return _accessTokenAspect.OpenId; }
            set { _accessTokenAspect.OpenId = value; }
        }
        public string AccessTokenCode
        {
            get { return _accessTokenAspect.AccessTokenCode; }
            set { _accessTokenAspect.AccessTokenCode = value; }
        }
        public string SessionKey
        {
            get { return _accessTokenAspect.SessionKey; }
            set { _accessTokenAspect.SessionKey = value; }

        }
    }
}
