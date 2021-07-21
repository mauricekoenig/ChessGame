


using System;

namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DebuggingToolAttribute : Attribute
    {
        public string Comment { get; }
        public DebuggingToolAttribute() {

        }
        public DebuggingToolAttribute (string comment) {

            Comment = comment;
        }
    }
}