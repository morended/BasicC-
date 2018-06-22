namespace CsharpBasics.DesignPatterns
{
    /*Simple Factory concept: This is not any pattern.
     *In this example we are encapsulating the object creation of Payment Type in to a factory method.
     * This way the client is decoupled from the object creation and seperated from the code that changes.
     * Adding or deleting a client can be handled in the factory method "CreatePaymentType"
   */
    public class SimpleFactory
    {
        public static IPaymentType CreatePaymentType(string type)
        {
            if (type.Equals("debit"))
            {
                return new DebitCard();
            }
            if (type.Equals("credit"))
            {
                return new CreditCard();
            }
            if (type.Equals("paypal"))
            {
                return new PayPal();
            }

            return null;
        }
    }

    public class ClientStore
    {
        public string pay(string type)
        {
           IPaymentType paymentType = SimpleFactory.CreatePaymentType(type);
            return paymentType.pay();
        }
  
    }

    public interface IPaymentType
    {
         string  pay();
    }

    public class CreditCard : IPaymentType
    {
        public string pay()
        {
            return "Payment made using creditcard";
        }
    }

    public class PayPal : IPaymentType
    {
        public string pay()
        {
            return "Payment made using PayPal";
        }
    }

    public class DebitCard : IPaymentType
    {
        public string pay()
        {
            return "Payment made using DebitCard";
        }
    }
}
