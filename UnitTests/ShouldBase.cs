using System;
using PaymentGateway.Models;

namespace UnitTests
{
    public class ShouldBase
    {
        protected static PaymentRequest BuildValidTestPaymentRequest()
        {
            return new PaymentRequest
            {
                CardNumber = "111111111111",
                CVV = "111",
                Amount = "12.12",
                ExpiryDate = "Test",
                RequestId = Guid.NewGuid().ToString(),
                RequestType = "Sandbox",
                Currency = "GBP"
            };
        }
    }
}