
using System;

namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class KingFlagAttribute : Attribute
    {
        public string Comment { get;}
        public KingFlagAttribute() {

        }
        public KingFlagAttribute (string comment) {
            this.Comment = comment;
        }
    }
}
