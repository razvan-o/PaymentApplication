using System;

namespace PaymentApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreditCard creditCard = new CreditCard();
            creditCard.SecurityCode = null;

            Console.WriteLine(creditCard.SecurityCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCard"> Already enforced by property setter to pass validation </param>
        /// <returns></returns>
        public PaymentProcessingResponse ProcessPayment(CreditCard creditCard)
        {
            return new PaymentProcessingResponse(false, "payment message") ;
        }
    }
}
