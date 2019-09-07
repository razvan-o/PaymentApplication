using System;

namespace PaymentApplication
{
    public class CreditCard : Attribute
    {
        private string creditCardNumber;
        private string cardHolder;
        private DateTime expirationDate;
        private int? securityCode;
        private decimal ammount;

        public string CreditCardNumber
        {
            get { return creditCardNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Credit card number can not be blank");
                if (value.Length != 16)
                    throw new ArgumentException(String.Format("Expected a 16 digits " +
                        "credit card number, but received: {0}\t({1} digits)", value, value.Length));
                creditCardNumber = value;
            }
        }

        public string CardHolder
        {
            get { return cardHolder; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Card holder value can not be blank");
                creditCardNumber = value;
            }
        }

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                if (value.CompareTo(DateTime.Now) < 0)
                    throw new ArgumentException("Card expiration date is in the past");
                expirationDate = value;
            }
        }

        public int? SecurityCode
        {
            get { return securityCode; }
            set
            {
                if (value != null)
                {
                    int digitsCount = value.ToString().Length;
                    if (digitsCount != 3)
                        throw new ArgumentException(String.Format("Expected a 3 digits " +
                            "security code, but received: {0}\t({1} digits)", value, digitsCount));
                }
                securityCode = value;
            }
        }

        public decimal Ammount
        {
            get { return ammount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(String.Format("Expected a positive " +
                        "ammount, but received: {0}", value));
                ammount = value;
            }
        }

    }
}
