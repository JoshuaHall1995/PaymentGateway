using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public class FakeBankApi: IBankAPI
    {
        public bool MakePayment(PaymentRequest request)
        {
            return true;
        }

        public FakeBankHistoricalPaymentRequest FetchPaymentDetails(string paymentId)
        {
            return new FakeBankHistoricalPaymentRequest();
        }
    }
}