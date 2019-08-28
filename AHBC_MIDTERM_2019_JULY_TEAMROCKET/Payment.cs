﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class Payment : IPaymentMethod
    {
        public double SubTotal { get; set; }
        public double SalesTaxTotal { get; set; }
        public double GrandTotal { get; set; }
        //public object PaymentType { get; private set; }
        public string Total { get; set; }

        public const double taxRate = 0.06;
        public ShoppingCart userShoppingCart = new ShoppingCart();

        public enum PaymentSelection
        {
            CreditCard = 1,
            Cash = 2,
            Check = 3

        };

        public void Pay(string total)
        {

        }

        public Payment(double subtotalFromShoppingcart, ShoppingCart shoppingCart)
        {
            SubTotal = subtotalFromShoppingcart;
            userShoppingCart.ItemstoPurchase = shoppingCart.ItemstoPurchase;
            
        }



        public double CalculatedSalesTaxTotal()
        {
            //sales tax total = subtotal * the taxrate of 6%
            SalesTaxTotal = SubTotal * taxRate;
            return SalesTaxTotal;
        }

        public double CalculatedGrandTotal()
        {
            // grand total = subtotal + tax total
            GrandTotal = SubTotal + SalesTaxTotal;
            return GrandTotal;
        }

        public void MethodOfPayment()
        {

            Console.Clear();
            Console.WriteLine("Please selece a method of payment (enter in number): " +
                "\n [1.] Credit Card" +
                "\n [2.] Cash" +
                "\n [3.] Check");
            //validating input with an enum try parse
            bool isInvalidInput = true;
            //While the input is invalid this loop will continue to run
            while (isInvalidInput)
            {
                if (Enum.TryParse<PaymentSelection>(Console.ReadLine(), out PaymentSelection userPaymentSelection))
                {
                    switch (userPaymentSelection)
                    {
                        case PaymentSelection.CreditCard:
                            CreditCard userCreditCard = new CreditCard();
                            userCreditCard.Pay(GrandTotal);
                            Receipt userReceipt = new Receipt(GrandTotal, SubTotal, userShoppingCart.ItemstoPurchase);
                            userReceipt.PrintReceipt();
                            Console.WriteLine("Thank you for your payment from the following credit card");
                            Console.WriteLine("Payment is processed and approved");
                            userCreditCard.printCardInfo();
                            return;

                        case PaymentSelection.Cash:
                            Cash userCash = new Cash();
                            userCash.Pay(GrandTotal);
                            Receipt cashUserReceipt = new Receipt(GrandTotal, SubTotal, userShoppingCart.ItemstoPurchase);
                            cashUserReceipt.PrintReceipt();
                            userCash.PrintCashInfo();
                            return;

                        case PaymentSelection.Check:
                            Check userCheck = new Check();
                            userCheck.Pay(GrandTotal);
                            Receipt checkUserReceipt = new Receipt(GrandTotal, SubTotal, userShoppingCart.ItemstoPurchase);
                            checkUserReceipt.PrintReceipt();
                            userCheck.PrintCheckInfo();
                            return;

                        default:
                            Console.WriteLine("I'm sorry but we do not accept this form of payment.");
                            break;
                    }

                }



            }


        }

        //public double AddingTaxRate()
        //{
        //** if we decide to do non-taxable items.. maybe rename this method??
        //}


        public interface IPayment
        {

        }
    }
}
