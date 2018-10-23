using System;

namespace WebFacade.Core.Exceptions
{
    public class NegativeUnixException: Exception
    {
        public NegativeUnixException(string message): base(message)
        {
        }
    }
}
