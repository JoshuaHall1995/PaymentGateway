using System;

namespace PaymentGateway.Models
{
    public class LoggedPaymentRequest
    {
        public string RequestId { get; set; }
        public string HashedCardNumber { get; set; }
        // Obvs dont want to store the card number ourselves. That is extra risk.
        public double Amount { get; set; }
        public string RequestType { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        
        public string Currency { get; set; }
        public bool Success { get; set; }
        // This again could be an enum once more error cases are possible. Instead of just Successful, Unsuccessful
        // could include more detailed reasons if the BankAPI's integrated with return them or we have a wider
        // collection of possible states.


    }
}