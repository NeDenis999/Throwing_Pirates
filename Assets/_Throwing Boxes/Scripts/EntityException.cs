using System;

namespace Throwing_Boxes
{
    public class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }
    }
}