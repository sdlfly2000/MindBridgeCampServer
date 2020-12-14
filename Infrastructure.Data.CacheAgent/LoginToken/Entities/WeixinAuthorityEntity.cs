using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.CacheAgent.LoginToken.Entities
{
    public class WeixinAuthorityEntity
    {
        public string SessionKey { get; set; }

        public string OpenId { get; set; }

        public string UnionId { get; set; }

        public Guid LoginToken { get; set; }

        public Guid AppInformationId { get; set; }

        public string AppName { get; set; }

        public string AppSecret { get; set; }

        public string WeixinAppId { get; set; }
    }
}
