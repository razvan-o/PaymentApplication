namespace PaymentApplication
{
    /// <summary>
    /// Class used to contain a Payment Request Response
    /// Used only for assertion of outputs in PaymentRequestHandlerTests.cs
    /// Can be expanded for serving a wider scope
    /// </summary>
    public class PaymentProcessingResponse
    {
        private bool paymentIsValid;
        private bool paymentIsExecuted;

        public PaymentProcessingResponse(bool paymentIsValid, bool paymentIsExecuted)
        {
            this.paymentIsValid = paymentIsValid;
            this.paymentIsExecuted = paymentIsExecuted;
        }

        public bool PaymentIsValid { get => paymentIsValid; set => paymentIsValid = value; }
        public bool PaymentIsExecuted { get => paymentIsExecuted; set => paymentIsExecuted = value; }
    }
}