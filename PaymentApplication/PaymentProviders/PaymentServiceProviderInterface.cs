namespace PaymentApplication
{
    /// <summary>
    /// Interface to define the structure for a Payment Service Provider
    /// </summary>
    public interface PaymentServiceProviderInterface
    {
        bool FulfillPayment(CreditCard creditCard, int retryAttempts);
        bool CheckServiceAvailability();
        void SignalPaymentFailure(CreditCard creditCard, string failureReason);
        void SignalPaymentSuccess(CreditCard creditCard);
    }
}
