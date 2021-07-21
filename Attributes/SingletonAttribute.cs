
using System;


namespace MauriceKoenig.ChessGame
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SingletonAttribute : Attribute
    {
        public string Comment { get; }
        public SingletonAttribute() {

        }
        public SingletonAttribute(string comment) {
            this.Comment = comment;
        }
    }
}