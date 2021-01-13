using Common.Core.AOP;
using Core;

namespace Domain.LearningRoom
{
    public class SignInReference : IReference
    {
        public SignInReference(string code, string fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.SignIn;
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
            return Code.Equals(((SignInReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
