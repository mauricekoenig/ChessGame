
using System;

namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class BaseClassAttribute : Attribute
    {
        public string Comment { get; }
        public BaseClassAttribute() {

        }
        public BaseClassAttribute(string comment) {
            this.Comment = comment;
        }
    }
}