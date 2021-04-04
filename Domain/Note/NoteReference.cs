using Common.Core.AOP;
using Core;
using System;

namespace Domain.Note
{
    public class NoteReference : IReference
    {
        public NoteReference(string code, string fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.Note;
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
            return Code.Equals(((NoteReference)obj).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static NoteReference Create()
        {
            return new NoteReference(Guid.NewGuid().ToString());
        }
    }
}
