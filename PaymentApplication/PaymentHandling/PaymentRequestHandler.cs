using System.Collections.Generic;

namespace PaymentApplication
{
    /// <summary>
    /// Entry point of the Payment functionality.
    /// </summary>
    public class PaymentRequestHandler
    {
        private static  PaymentValidator paymentValidator;
        private static PaymentExecutor paymentExecutor;

        public PaymentRequestHandler() : this(new PaymentValidator(), new PaymentExecutor()) { }

        public PaymentRequestHandler(PaymentValidator paymentValidatorInjected, PaymentExecutor paymentExecutorInjected)
        {
            paymentValidator = paymentValidatorInjected;
            paymentExecutor = paymentExecutorInjected;
        }

        /// <summary>
        /// Initiates the validation and execution of payment
        /// </summary>
        /// <param name="creditCard"> Contains payment data.
        ///     Any instance of ValidCreditCard would already be enforced with the correct data to pass validation </param>
        public PaymentProcessingResponse ProcessPayment(CreditCard creditCard)
        {
            bool paymentIsValid = RequestPaymentValidation(creditCard);

            bool paymentIsExecuted;
            if (paymentIsValid)
                paymentIsExecuted = paymentExecutor.ExecutePayment(creditCard);
            else
                paymentIsExecuted = false;

            return new PaymentProcessingResponse(paymentIsValid, paymentIsExecuted);
        }

        private bool RequestPaymentValidation(CreditCard creditCard)
        {
            List<string> validationErrors = paymentValidator.CheckForValidationErrors(creditCard);
            if (validationErrors.Count == 0)
                return true;
            else
                return false;
        }

    }
}
