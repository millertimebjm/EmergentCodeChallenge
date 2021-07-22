using System;

namespace Emergent.Software
{
    public class InvalidVersionCharacterException : Exception
    {
        public InvalidVersionCharacterException() : base()
        {

        }
        public InvalidVersionCharacterException(string? message) : base(message)
        {

        }
    }
}
