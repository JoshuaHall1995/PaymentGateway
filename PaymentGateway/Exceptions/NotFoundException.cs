using System;

namespace PaymentGateway.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string errors)
            : base(message: errors)
        {
        }

        public NotFoundException()
        {
        }
    }
}