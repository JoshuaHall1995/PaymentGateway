using System;

namespace PaymentGateway.Models
{
    // This could be replaced with just a object that is passed up with the properties named as we would like.
    // Model is for neatness. In a world where the LoggedPaymentRequest would be stored elsewhere the appearance
    // of so many closely named models would not exist.
    
    // Also useful for mapping so we do not return unwanted fields etc. 
    public class HistoricalPaymentRecord
    {
        public string RequestId { get; set; }
        // Use Json Property later to make sure this returns as "CardNumber" to user but looks like hashed for us. 
        public string HashedCardNumber { get; set; }
        public double Amount { get; set; }
        public bool Success { get; set; }
        public string Currency { get; set; }
    }
}