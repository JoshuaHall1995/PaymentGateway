using Newtonsoft.Json;

namespace PaymentGateway.Models
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        
        public string Amount { get; set; }
        public string CVV { get; set; }
        public string RequestType { get; set; } 
        // Would be Sandbox if test request, easier for routing and is a practice I have seen in multiple third party Apis.
        // Could be an enum stored in a common package. A string is fine for now. Or this could be used as a query param
        // so we can check on each endpoint if it is a sandbox then reroute it to the FakeBankApi in the future for testing.
        public string RequestId { get; set; } 
        // In this imaginary world when each payment is created they provide us a id. This could be a guid they
        // create for each request or a combination of ISO timestamp and payment details. This is to make tracking
        // previous transactions easier and for duplicate identifaction. 
        
        public string Currency { get; set; } 
        // Could be a enum so we can check it is against a selected list of curre cies accepted by the bank.
    }
}