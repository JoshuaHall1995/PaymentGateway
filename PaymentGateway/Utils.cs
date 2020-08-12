using System;
using PaymentGateway.Models;

namespace PaymentGateway
{
    public class Utils
    {
        // These methods could live in the common shared package. Here now for convenience.
        // Test wise these are small used in other places so are covered. If they start getting
        // smarter they would require tests. 
        
        // Aka Acceptance Test on GetPaymentRequest would be able to check the card number is returned as a hash etc

        private string HashCardNumber(string cardNumber)
        {
            // Change all chars to * aside from final 4 digits
            return null;
        }

        public LoggedPaymentRequest MapToLoggedPaymentRequest(PaymentRequest request, bool isSuccess)
        {
            return new LoggedPaymentRequest
            {
                Amount = request.Amount,
                HashedCardNumber = HashCardNumber(request.CardNumber),
                RequestId = request.RequestId,
                RequestType = request.RequestType,
                Timestamp = DateTimeOffset.UtcNow,
                Success = isSuccess
            };
        }
    }
}