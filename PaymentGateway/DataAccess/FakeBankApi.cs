using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public class FakeBankApi: IBankAPI
    {
        public bool MakePayment(PaymentRequest request)
        {
            // These would either be http calls to another APi running locally or to a cloud based deployment
            return true;
        }

        public FakeBankHistoricalPaymentRequest FetchPaymentDetails(string paymentId)
        {
            return new FakeBankHistoricalPaymentRequest();
        }
    }
}