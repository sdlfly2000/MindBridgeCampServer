using Common.Core.AOP;
using Core;

namespace Domain.LearningRoom
{
    public class ParticipantReference : IReference
    {
        public ParticipantReference(string code, string fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.Participant;
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
            return Code.Equals(((ParticipantReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
