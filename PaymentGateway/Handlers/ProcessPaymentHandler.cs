using System;
using PaymentGateway.Models;

namespace PaymentGateway.Handlers
{
    public class ProcessPaymentHandler
    {
        private readonly IPaymentHistoryRepo _paymentHistoryRepo;
        private readonly IBankAPI _bankApi;

        public ProcessPaymentHandler(IPaymentHistoryRepo paymentHistoryRepo, IBankAPI bankApi)
        {
            _paymentHistoryRepo = paymentHistoryRepo;
            _bankApi = bankApi;
        }
        
        public bool Handle(PaymentRequest paymentRequest)
        {
            // is duplicate
            
            // attempt payment (assume response bool although in reality will prob be http)
            
            // log request with result
            
            // return result
            throw new NotImplementedException();
        }
    }
}