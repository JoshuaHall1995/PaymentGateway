using System;

namespace PaymentGateway.Models
{
    public class FakeBankHistoricalPaymentRequest : PaymentRequest
    {
        // If this were a third party API like Apple they all have their own format to map too. We care about knowing
        // if the request was a success, hashing it etc. For simplicity I assumed they return the same request we sent
        // then just with a success flag. 
        
        public bool Success { get; set; }
    }
}