using System;

namespace PaymentApplication
{
    /// <summary>
    /// Class in charge of ordering execution of payment to the appropriate PaymentServiceProvider
    /// </summary>
    public class PaymentExecutor
    {
        private static PaymentProviderFactory paymentProviderFactory;
        private static PaymentServiceProvider paymentServiceProvider;

        public PaymentExecutor() : this(new PaymentProviderFactory()) { }

        public PaymentExecutor(PaymentProviderFactory paymentProviderFactoryInjected)
        {
            paymentProviderFactory = paymentProviderFactoryInjected;
        }

        /// <summary>
        /// Determines what PaymentProvider should be used and initiates the payment process
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns> TRUE if payment was executed successfully/returns>
        public bool ExecutePayment(CreditCard creditCard)
        {
            bool successfulPayment;
            decimal paymentAmmount = creditCard.Ammount;

            if (paymentAmmount > 0 && paymentAmmount < 21)
                successfulPayment = ExecuteCheapPayment(creditCard);
            else if (paymentAmmount >= 21 && paymentAmmount <= 500)
                successfulPayment = ExecuteExpensivePayment(creditCard);
            else if (paymentAmmount > 500)
                successfulPayment = ExecutePremiumPayment(creditCard);
            else
                throw new ArgumentException("The ammount received is not valid");

            return successfulPayment;
        }

        private bool ExecuteCheapPayment(CreditCard creditCard)
        {
            int retryAttempts = 1;
            return ExecuteCheapPayment(creditCard, retryAttempts);
        }

        private bool ExecuteCheapPayment(CreditCard creditCard, int retryAttempts)
        {
            paymentServiceProvider = paymentProviderFactory.DelegatePaymentServiceProvider(PaymentProviders.CheapPaymentService);
            return paymentServiceProvider.FulfillPayment(creditCard, retryAttempts);
        }

        private bool ExecuteExpensivePayment(CreditCard creditCard)
        {
            paymentServiceProvider = paymentProviderFactory.DelegatePaymentServiceProvider(PaymentProviders.ExpensivePaymentService);

            int retryAttempts = 1;
            bool paymentFulfilled = paymentServiceProvider.FulfillPayment(creditCard, retryAttempts);

            if (!paymentFulfilled)
                paymentFulfilled = ExecuteCheapPayment(creditCard, retryAttempts);

            return paymentFulfilled;
        }

        private bool ExecutePremiumPayment(CreditCard creditCard)
        {
            paymentServiceProvider = paymentProviderFactory.DelegatePaymentServiceProvider(PaymentProviders.PremiumPaymentService);

            int retryAttempts = 3;
            return paymentServiceProvider.FulfillPayment(creditCard, retryAttempts);
        }
    }
}
