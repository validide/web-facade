using System;

namespace WebFacade.Core.Exceptions
{
    public class DateTimeKindException: Exception
    {
        public DateTimeKindException(string message): base(message)
        {
        }
    }
}
