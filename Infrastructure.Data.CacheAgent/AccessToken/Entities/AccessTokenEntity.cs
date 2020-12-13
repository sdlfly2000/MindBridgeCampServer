using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.CacheAgent.AccessToken.Entities
{
    public class AccessTokenEntity
    {
        public string OpenId { get; set; }

        public string SessionKey { get; set; }
    }
}
