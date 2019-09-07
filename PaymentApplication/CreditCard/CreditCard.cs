using System;

namespace PaymentApplication
{
    /// <summary>
    /// CreditCard class with no validation;
    /// Allows testing payment handling methods with non-valid parameters;
    /// </summary>
    public class CreditCard
    {
        private readonly string creditCardNumber;
        private readonly string cardHolder;
        private readonly DateTime expirationDate;
        private readonly int? securityCode;
        private readonly decimal ammount;

        // Constructor without optional securityCode attribute
        public CreditCard(string creditCardNumber, string cardHolder, DateTime expirationDate, decimal ammount)
            : this(creditCardNumber, cardHolder, expirationDate, null, ammount) { }

        public CreditCard(string creditCardNumber, string cardHolder, DateTime expirationDate, int? securityCode, decimal ammount)
        {
            this.creditCardNumber = creditCardNumber;
            this.cardHolder = cardHolder;
            this.expirationDate = expirationDate;
            this.securityCode = securityCode;
            this.ammount = ammount;
        }

        public string CreditCardNumber => creditCardNumber;

        public string CardHolder => cardHolder;

        public DateTime ExpirationDate => expirationDate;

        public int? SecurityCode => securityCode;

        public decimal Ammount => ammount;
    }
}
