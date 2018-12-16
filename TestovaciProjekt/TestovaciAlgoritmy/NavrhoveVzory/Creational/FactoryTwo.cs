using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovaciAlgoritmy.NavrhoveVzory.Creational
{
    public class PaymentProcessor
    {
        IPaymentGateway gateway = null;

        public void MakePayment(PaymentMethod method, Product product)
        {
            FactoryTwo factory = new FactoryTwo();
            this.gateway = factory.CreatePaymentGateway(method, product);

            this.gateway.MakePayment(product);
        }
    }
    public class PaymentProcessor2
    {
        IPaymentGateway gateway = null;

        public void MakePayment(PaymentMethod method, Product product)
        {
            FactoryTwo2 factory = new FactoryTwo2();
            this.gateway = factory.CreatePaymentGateway(method, product);

            this.gateway.MakePayment(product);
        }
    }

    class FactoryTwo
    {
        public virtual IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.BANK_ONE:
                    gateway = new BankOne();
                    break;
                case PaymentMethod.BANK_TWO:
                    gateway = new BankTwo();
                    break;
                case PaymentMethod.BEST_FOR_ME:
                    if (product.Price < 50)
                    {
                        gateway = new BankTwo();
                    }
                    else
                    {
                        gateway = new BankOne();
                    }
                    break;
            }
            return gateway;
        }
    }
    class FactoryTwo2 : FactoryTwo
    {
        public override IPaymentGateway CreatePaymentGateway(PaymentMethod method, Product product)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case PaymentMethod.PAYPAL:
                     gateway = new PayPal();
                    break;
                case PaymentMethod.BILL_DESK:
                    gateway = new BillDesk();
                    break;
                default:
                    gateway = base.CreatePaymentGateway(method, product);
                    break;
            }

            return gateway;
        }
    }

    interface IPaymentGateway
    {
        void MakePayment(Product product);
    }

    class BankOne : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            Console.WriteLine("Using bank1 to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    class BankTwo : IPaymentGateway
    {
        public void MakePayment(Product product)
        {   
            Console.WriteLine("Using bank2 to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    class PayPal : IPaymentGateway
    {
        public void MakePayment(Product product)
        {   
            Console.WriteLine("Using PayPal to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    class BillDesk : IPaymentGateway
    {
        public void MakePayment(Product product)
        {   
            Console.WriteLine("Using BillDesk to pay for {0}, amount {1}", product.Name, product.Price);
        }
    }

    public enum PaymentMethod
    {
        BANK_ONE,
        BANK_TWO,
        BEST_FOR_ME,

        PAYPAL,
        BILL_DESK
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
