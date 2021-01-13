using Common.Core.AOP;
using Core;

namespace Domain.LearningRoom
{
    public class ChatReference : IReference
    {
        public ChatReference(string code, string fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.Chat;
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
