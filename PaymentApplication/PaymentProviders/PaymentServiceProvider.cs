using System;

namespace PaymentApplication
{
    public abstract class PaymentServiceProvider : PaymentServiceProviderInterface
    {

        /// <summary>
        /// When fulfilling a payment, first check if the service is available, then attempt to wire the monney.
        /// 
        /// Despite having almost identical implementation of this function for all the PaymentProviders, I chose to
        ///     override it for each provider, as in a business scenario providers would have different implementations.
        /// </summary>
        /// <returns> TRUE if payment was fulfilled successfully </returns>
        public abstract bool FulfillPayment(CreditCard creditCard, int retryAttempts);

        // Method to simulate an availabilityCheck call before attempting to wire monney
        public bool CheckServiceAvailability()
        {
            // As requested, assume services to always be available
            return true;
        }

        /// <summary>
        /// Logging failure-of-payment event
        /// </summary>
        /// <param name="creditCard"> creditCard for which payment failed </param>
        /// <param name="failureReason"> reason of failure </param>
        public void SignalPaymentFailure(CreditCard creditCard, string failureReason)
        {
            Console.WriteLine(String.Format("Payment could not be executed for credit " +
                "card number: {0};\t ammount: {1}\nReason for failure: {2}",
                creditCard.CreditCardNumber, creditCard.Ammount, failureReason));
        }

        /// <summary>
        /// Logging succesfull-payment event
        /// </summary>
        /// <param name="creditCard"> creditCard for which payment was fulfilled </param>
        public void SignalPaymentSuccess(CreditCard creditCard)
        {
            Console.WriteLine(String.Format("Payment executed successfully.\n" +
                "\t{0}£ were transfered from card: {1}, using {2}",
                creditCard.Ammount, creditCard.CreditCardNumber, GetType().Name));
        }
    }
}
