
using System;


namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CachePropertyAttribute : Attribute
    {
        public string Comment { get; }
        public CachePropertyAttribute() {

        }
        public CachePropertyAttribute (string comment) {
            this.Comment = comment;
        }
    }
}
