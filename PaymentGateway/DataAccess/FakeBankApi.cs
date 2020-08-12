using PaymentGateway.Models;

namespace PaymentGateway.DataAccess
{
    public class FakeBankApi: IBankAPI
    {
        public bool MakePayment(PaymentRequest request)
        {
            throw new System.NotImplementedException();
        }

        public FakeBankHistoricalPaymentRequest FetchPaymentDetails(string paymentId)
        {
            throw new System.NotImplementedException();
        }
    }
}