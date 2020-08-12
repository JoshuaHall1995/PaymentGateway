using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public class PaymentHistoryRepo : IPaymentHistoryRepo
    {
        public void LogPayment(LoggedPaymentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDuplicate(string PaymentId)
        {
            throw new System.NotImplementedException();
        }
    }
}