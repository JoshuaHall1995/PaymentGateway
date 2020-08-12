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

        public static string HashCardNumber(string cardNumber)
        {
            var length = cardNumber.Length;
            return new string('*', length - 4) + cardNumber.Substring(length - 4);

        }

        public static LoggedPaymentRequest MapToLoggedPaymentRequest(PaymentRequest request, bool isSuccess)
        {
            return new LoggedPaymentRequest
            {
                Amount = Convert.ToDouble(request.Amount),
                HashedCardNumber = HashCardNumber(request.CardNumber),
                RequestId = request.RequestId,
                RequestType = request.RequestType,
                Timestamp = DateTimeOffset.UtcNow,
                Success = isSuccess
            };
        }
        
        // Duplicate functionality to above but as mentioned elsewhere the above would be stored elsewhere in a
        // real implementation. 
        public static HistoricalPaymentRecord MapToHistoricalPaymentRecord(FakeBankHistoricalPaymentRequest request)
        {
            return new HistoricalPaymentRecord
            {
                Amount = Convert.ToDouble(request.Amount),
                HashedCardNumber = HashCardNumber(request.CardNumber),
                RequestId = request.RequestId,
                Success = request.Success
            };
        }
    }
}