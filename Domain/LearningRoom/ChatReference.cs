using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.LearningRoom
{
    using Common.Core.AOP;

    public class ChatReference : IReference
    {
        public ChatReference(string code, string fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? string.Empty;
        }

        public string Code { get; set; }

        public string CacheFieldName { get; set; }

        public string CacheCode
        {
            get
            {
                return CacheFieldName.Equals(string.Empty)
                           ? string.Empty
                           : string.Concat(CacheFieldName, Code);
            }
        }

        public override bool Equals(object obj)
        {
            return Code.Equals(((ChatReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
