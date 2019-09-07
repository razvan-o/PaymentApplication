using System;

namespace PaymentApplication
{
    public class CheapPaymentService : PaymentServiceProvider
    {
        public override bool FulfillPayment(CreditCard creditCard, int retryAttempts)
        {
            if (CheckServiceAvailability())
            {
                bool isPaymentFulfilled;

                // Try sending monney {{retryAttempts}} times
                do
                {
                    isPaymentFulfilled = WireMonney(creditCard);
                }
                while ((--retryAttempts > 0) && !isPaymentFulfilled);

                if (!isPaymentFulfilled)
                {
                    string failureReason = "CheapPaymentService System error while wiring monney";
                    SignalPaymentFailure(creditCard, failureReason);
                }
                else
                    SignalPaymentSuccess(creditCard);

                return isPaymentFulfilled;
            }
            else
            {
                string failureReason = "CheapPaymentService is unavailable at the moment.";
                SignalPaymentFailure(creditCard, failureReason);
                return false;
            }
        }

        /// <summary>
        /// Just to ilustrate handling errors at runtime
        /// </summary>
        /// <returns> TRUE if monney were wired successfully </returns>
        private bool WireMonney(CreditCard creditCard)
        {
            try
            {
                //  <payment logic for CheapPaymentService>
            }
            catch (TimeoutException)
            {
                // handle error / write logs;
                return false;
            }

            return true;
        }
    }
}
