using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public interface IPaymentHistoryRepo
    {
        void LogPayment(LoggedPaymentRequest request);
        bool IsDuplicate(string PaymentId);
        // Is done by Id. This could be extended in future to instead of just checking if duplicate if another payment
        // was requested in a predetemrined time frame to add more rules and security around repeat payment if needed.
    }
}