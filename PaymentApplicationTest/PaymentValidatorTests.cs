using System;
using System.Collections.Generic;
using NUnit.Framework;
using PaymentApplication;

namespace Tests
{
    /// <summary>
    /// Payment process scenario covered: The Credit Card validation fails for the CreditCardNumber and the ExpirationDate.
    /// </summary>
    public class PaymentValidatorTests
    {
        private static PaymentValidator paymentValidator;
        private static CreditCard validCreaditCardCheap;
        private static CreditCard validCreaditCardExpensive;
        private static CreditCard validCreaditCardPremium;
        private static CreditCard nonValidCreaditCardCheap;
        private static CreditCard nonValidCreaditCardExpensive;
        private static CreditCard nonValidCreaditCardPremium;

        [SetUp]
        public void Setup()
        {
            paymentValidator = new PaymentValidator();

            string validCreditCardNumber = "1111222233334444";
            string shortCreditCardNumber = "111122223333";
            string emptyCreditCardNumber = "";
            string nullCreditCardNumber = null;


            string cardHolder = "Razvan Olariu";

            DateTime validDate = new DateTime(2046, 7, 15, 3, 15, 0);
            DateTime dateInPast = new DateTime(2016, 7, 15, 3, 15, 0);

            decimal cheapPaymentAmmount = 11;
            decimal expensivePaymentAmmount = 211;
            decimal premiumPaymentAmmount = 1011;

            validCreaditCardCheap = new CreditCard(validCreditCardNumber, cardHolder, validDate, cheapPaymentAmmount);
            validCreaditCardExpensive = new CreditCard(validCreditCardNumber, cardHolder, validDate, expensivePaymentAmmount);
            validCreaditCardPremium = new CreditCard(validCreditCardNumber, cardHolder, validDate, premiumPaymentAmmount);

            nonValidCreaditCardCheap = new CreditCard(shortCreditCardNumber, cardHolder, dateInPast, cheapPaymentAmmount);
            nonValidCreaditCardExpensive = new CreditCard(emptyCreditCardNumber, cardHolder, dateInPast, expensivePaymentAmmount);
            nonValidCreaditCardPremium = new CreditCard(nullCreditCardNumber, cardHolder, dateInPast, premiumPaymentAmmount);
        }

        [Test]
        public void CheckForValidationErrors_ValidCreditCards()
        {
            List<string> errorsListCheapPayment = paymentValidator.CheckForValidationErrors(validCreaditCardCheap);
            List<string> errorsListExpensivePayment = paymentValidator.CheckForValidationErrors(validCreaditCardExpensive);
            List<string> errorsListPremiumPayment = paymentValidator.CheckForValidationErrors(validCreaditCardPremium);
            List<string> expectedErorsList = new List<string>();

            Assert.AreEqual(errorsListCheapPayment, expectedErorsList);
            Assert.AreEqual(errorsListExpensivePayment, expectedErorsList);
            Assert.AreEqual(errorsListPremiumPayment, expectedErorsList);
        }

        [Test]
        public void CheckForValidationErrors_NonValidCreditCards()
        {
            List<string> errorsListCheapPayment = paymentValidator.CheckForValidationErrors(nonValidCreaditCardCheap);
            List<string> errorsListExpensivePayment = paymentValidator.CheckForValidationErrors(nonValidCreaditCardExpensive);
            List<string> errorsListPremiumPayment = paymentValidator.CheckForValidationErrors(nonValidCreaditCardPremium);

            List<string> expectedErorsForShortCardNumber = new List<string>();
            expectedErorsForShortCardNumber.Add("Credit card number must contain 16 digits.");
            expectedErorsForShortCardNumber.Add("Card expiration date is in the past");

            List<string> expectedErorsForBlankCardNumber = new List<string>();
            expectedErorsForBlankCardNumber.Add("Credit card number can not be blank.");
            expectedErorsForBlankCardNumber.Add("Card expiration date is in the past");

            Assert.AreEqual(errorsListCheapPayment, expectedErorsForShortCardNumber);
            Assert.AreEqual(errorsListExpensivePayment, expectedErorsForBlankCardNumber);
            Assert.AreEqual(errorsListPremiumPayment, expectedErorsForBlankCardNumber);
        }
    }
}