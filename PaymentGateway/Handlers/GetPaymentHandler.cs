using System;
using PaymentGateway.Models;

namespace PaymentGateway.Handlers
{
    public class GetPaymentHandler
    {
        private readonly IBankAPI _bankApi;

        public GetPaymentHandler( IBankAPI bankApi)
        {
            _bankApi = bankApi;
        }

        public HistoricalPaymentRecord Handle(string paymentId)
        {
         
            // call getPayment
            
            // hash CardNumber
            
            // map to the expected response.
            
            throw new NotImplementedException();
        }
        
        // This handler is looking to the external BankApi instead of our own payment records just for maximum
        // consistency. In reality there could be two implementations depending on how consistent we choose to
        // handle our data. Querying our own storage, depending on structure, could be faster then third party usage.
        
        // This also gives us the reliability option if a third party api fails to fall back on our own records.
    }
}