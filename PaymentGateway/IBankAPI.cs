using PaymentGateway.Models;

namespace PaymentGateway
{
    public interface IBankAPI
    {
        bool MakePayment(PaymentRequest request);
        void FetchPaymentDetails();
    }
}