


using System;

namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class PawnFlagAttribute : Attribute
    {
        public string Comment { get; }
        public PawnFlagAttribute() {

        }
        public PawnFlagAttribute(string comment) {
            this.Comment = comment;
        }
    }
}