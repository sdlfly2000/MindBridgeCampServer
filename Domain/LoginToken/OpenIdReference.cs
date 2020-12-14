using System;

namespace Domain.LoginToken
{
    public class OpenIdReference
    {
        public OpenIdReference(Guid code)
        {
            Code = code;
        }

        public Guid Code { get; set; }

        public override bool Equals(object obj)
        {
            return Code.Equals(((OpenIdReference)obj).Code);
        }

        public override string ToString()
        {
            return Code.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
