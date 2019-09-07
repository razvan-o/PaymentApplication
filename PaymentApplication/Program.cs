using System;
    
namespace PaymentApplication
{
    class Program
    {
        /// <summary>
        /// Entry point of PaymentApplication solution.
        /// Provides a fast testing for the requested Payment Process Scenarios
        /// Additional testing can be found in PaymentApplicationTest solution
        /// </summary>
        static void Main(string[] args)
        {
            PaymentRequestHandler paymentRequestHandler = new PaymentRequestHandler();

            string validCreditCardNumber = "1111222233334444";
            string shortCreditCardNumber = "111122223333";

            string cardHolder = "Razvan Olariu";

            DateTime validDate = new DateTime(2046, 7, 15, 3, 15, 0);
            DateTime dateInPast = new DateTime(2016, 7, 15, 3, 15, 0);

            decimal expensivePaymentAmmount = 211;

            CreditCard validCreaditCardExpensive = new CreditCard(validCreditCardNumber, cardHolder, validDate, expensivePaymentAmmount);
            CreditCard nonValidCreaditCardExpensive = new CreditCard(shortCreditCardNumber, cardHolder, dateInPast, expensivePaymentAmmount);

            Console.WriteLine("\nPayment Process Scenario: The Credit Card validation fails for the CreditCardNumber and the ExpirationDate.");
            paymentRequestHandler.ProcessPayment(nonValidCreaditCardExpensive);

            Console.WriteLine("\nPayment Process Scenario: The payment is processed for an Expensive amount.");
            paymentRequestHandler.ProcessPayment(validCreaditCardExpensive);
        }

       
    }
}
