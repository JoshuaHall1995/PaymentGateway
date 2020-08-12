using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public interface IBankAPI
    {
        bool MakePayment(PaymentRequest request);
        FakeBankHistoricalPaymentRequest FetchPaymentDetails(string paymentId);
    }
}