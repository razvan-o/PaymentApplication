using System;
namespace PaymentApplication
{
    /// <summary>
    /// Factory returning the appropriate child of PaymentServiceProvider
    /// </summary>
    public class PaymentProviderFactory
    {
        public PaymentServiceProvider DelegatePaymentServiceProvider(PaymentProviders paymentProvider)
        {
            if (paymentProvider.Equals(PaymentProviders.CheapPaymentService))
                return new CheapPaymentService();
            else if (paymentProvider.Equals(PaymentProviders.ExpensivePaymentService))
                return new ExpensivePaymentService();
            else if (paymentProvider.Equals(PaymentProviders.PremiumPaymentService))
                return new PremiumPaymentService();
            else
                throw new ArgumentException("The PaymentProvider received is not valid");
        }
    }
}
