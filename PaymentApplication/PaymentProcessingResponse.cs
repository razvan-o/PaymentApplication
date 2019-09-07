namespace PaymentApplication
{
    public class PaymentProcessingResponse
    {
        private bool v1;
        private string v2;

        public PaymentProcessingResponse(bool v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        private bool Status { get; }
        private string Message { get; }

    }
}