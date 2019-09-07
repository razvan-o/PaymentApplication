using System;
using System.Collections.Generic;

namespace PaymentApplication
{
    /// <summary>
    /// Validation for CreditCard fields.
    /// Similar logic cand be found in ValidCreditCard.
    /// </summary>
    public class PaymentValidator
    {
        public List<string> CheckForValidationErrors(CreditCard creditCard)
        {
            List<string> validationErrors = new List<string>();

            ValidateCreditCardNumber(creditCard.CreditCardNumber, validationErrors);
            ValidateCreditCardHolder(creditCard.CardHolder, validationErrors);
            ValidateCreditCardExpirationDate(creditCard.ExpirationDate, validationErrors);
            ValidateCreditCardSecurityCode(creditCard.SecurityCode, validationErrors);
            ValidatePaymentAmmount(creditCard.Ammount, validationErrors);

            displayValidationErrors(validationErrors);

            return validationErrors;
        }

        private bool ValidateCreditCardNumber(string creditCardNumber, List<string> validationErrors)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                validationErrors.Add("Credit card number can not be blank.");
                return false;
            }
            if (creditCardNumber.Length != 16)
            {
                validationErrors.Add("Credit card number must contain 16 digits.");
                return false;
            }
            return true;
        }

        private bool ValidateCreditCardHolder(string cardHolder, List<string> validationErrors)
        {
            if (string.IsNullOrEmpty(cardHolder))
            {
                validationErrors.Add("Credit card holder can not be blank");
                return false;
            }
            return true;
        }

        private bool ValidateCreditCardExpirationDate(System.DateTime expirationDate, List<string> validationErrors)
        {
            if (expirationDate.CompareTo(DateTime.Now) < 0)
            {
                validationErrors.Add("Card expiration date is in the past");
                return false;
            }
            return true;
        }

        private bool ValidateCreditCardSecurityCode(int? securityCode, List<string> validationErrors)
        {
            if (securityCode != null)
            {
                int digitsCount = securityCode.ToString().Length;
                if (digitsCount != 3)
                {
                    validationErrors.Add("Security code must contain 3 digits");
                    return false;
                }
            }
            return true;
        }

        private bool ValidatePaymentAmmount(decimal ammount, List<string> validationErrors)
        {
            if (ammount <= 0)
            {
                validationErrors.Add("Payment ammount must be positive");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Display the list of validation errors generated in CheckForValidationErrors method.
        /// </summary>
        /// <returns> TRUE if outputting the errors was successful</returns>
        private bool displayValidationErrors(List<string> validationErrors)
        {
            if (validationErrors == null || validationErrors.Count == 0)
                return false;

            Console.WriteLine("Payment could not be executed - CreditCard object is not valid");
            foreach (string error in validationErrors)
                Console.WriteLine("\t" + error);

            return true;
        }
    }
}