using Common.Core.AOP;

namespace Domain.User
{
    public class UserReference : IReference
    {
        public UserReference(string code, string fieldName = null)
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
                    : string.Join(CacheFieldName, Code); 
            } 
        }

        public override bool Equals(object obj)
        {
            return Code.Equals(((UserReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
