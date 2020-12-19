using Core;

namespace Domain.LoginToken
{
    public class OpenIdReference : IReference
    {
        public OpenIdReference(string code)
        {
            Code = code;
        }

        public string Code { get; set; }

        public override bool Equals(object obj)
        {
            return Code.Equals(((OpenIdReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
