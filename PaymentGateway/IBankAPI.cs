namespace PaymentGateway
{
    public interface IBankAPI
    {
        void MakePayment();
        void FetchPaymentDetails();
    }
}