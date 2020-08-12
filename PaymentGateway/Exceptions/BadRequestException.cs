using System;

namespace PaymentGateway.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string errors)
            : base(message: errors)
        {
        }

        public BadRequestException()
        {
        }
    }
}