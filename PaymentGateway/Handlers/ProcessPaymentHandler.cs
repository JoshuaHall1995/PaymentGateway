using PaymentGateway.Exceptions;
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
            if (_paymentHistoryRepo.IsDuplicate(paymentRequest.RequestId))
                throw new BadRequestException("Duplicate request.");

            var isSuccessfulPayment = _bankApi.MakePayment(paymentRequest);
            //(assume response bool for simplicity although in reality will prob be http)

            if (isSuccessfulPayment)
            {
                _paymentHistoryRepo.LogPayment(Utils.MapToLoggedPaymentRequest(paymentRequest, true));
                return true;
            }

            _paymentHistoryRepo.LogPayment(Utils.MapToLoggedPaymentRequest(paymentRequest, false));
            return false;
        }
    }
}