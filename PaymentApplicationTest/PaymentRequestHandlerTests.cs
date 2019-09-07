using System;
using NUnit.Framework;
using PaymentApplication;

namespace Tests
{
    /// <summary>
    /// Payment process scenario covered: The payment is processed for an Expensive amount.
    /// </summary>
    public class PaymentRequestHandlerTests
    {
        private static PaymentRequestHandler paymentRequestHandler;
        private static CreditCard nonValidCreaditCardExpensive;
        private static CreditCard validCreaditCardExpensive;

        [SetUp]
        public void Setup()
        {
            paymentRequestHandler = new PaymentRequestHandler();

            string validCreditCardNumber = "1111222233334444";
            string emptyCreditCardNumber = "";
            string cardHolder = "Razvan Olariu";
            DateTime validDate = new DateTime(2046, 7, 15, 3, 15, 0);
            decimal expensivePaymentAmmount = 211;

            validCreaditCardExpensive = new CreditCard(validCreditCardNumber, cardHolder, validDate, expensivePaymentAmmount);
            nonValidCreaditCardExpensive = new CreditCard(emptyCreditCardNumber, cardHolder, validDate, expensivePaymentAmmount);
        }

        [Test]
        public void ProcessPayment_ValidCreditCards()
        {
            PaymentProcessingResponse validCardPaymentProcessingResponse = paymentRequestHandler.ProcessPayment(validCreaditCardExpensive);
            Assert.IsTrue(validCardPaymentProcessingResponse.PaymentIsValid);
            Assert.IsTrue(validCardPaymentProcessingResponse.PaymentIsExecuted);
        }


        [Test]
        public void ProcessPayment_nonValidCreditCards()
        {
            PaymentProcessingResponse nonValidCardPaymentProcessingResponse = paymentRequestHandler.ProcessPayment(nonValidCreaditCardExpensive);
            Assert.IsFalse(nonValidCardPaymentProcessingResponse.PaymentIsValid);
            Assert.IsFalse(nonValidCardPaymentProcessingResponse.PaymentIsExecuted);
        }

    }
}