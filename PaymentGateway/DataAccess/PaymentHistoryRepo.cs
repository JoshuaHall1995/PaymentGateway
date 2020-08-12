using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public class PaymentHistoryRepo : IPaymentHistoryRepo
    {
        public void LogPayment(LoggedPaymentRequest request)
        {
        }

        public bool IsDuplicate(string PaymentId)
        {
            return false;
        }
    }
}