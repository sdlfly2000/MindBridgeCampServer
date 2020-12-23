using Common.Core.AOP;

namespace Domain.LearningRoom
{
    public class RoomReference : IReference
    {
        public RoomReference(string code, string fieldName = null)
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
            return Code.Equals(((RoomReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
