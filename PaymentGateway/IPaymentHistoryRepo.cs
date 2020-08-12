namespace PaymentGateway
{
    public interface IPaymentHistoryRepo
    {
        void LogPayment();
        bool IsDuplicate();
    }
}