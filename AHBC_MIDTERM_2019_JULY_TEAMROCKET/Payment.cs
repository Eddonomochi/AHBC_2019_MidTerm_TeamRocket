using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class Payment /*: IPaymentMethod*/
    {
        public double SubTotal { get; set; }
        public double SalesTaxTotal { get; set; }
        public double GrandTotal { get; set; }
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
            SalesTaxTotal = Math.Round(SalesTaxTotal, 2, MidpointRounding.AwayFromZero);
            return SalesTaxTotal;
        }

        public double CalculatedGrandTotal()
        {
            // grand total = subtotal + tax total
            GrandTotal = SubTotal + SalesTaxTotal;
            GrandTotal = Math.Round(GrandTotal, 2, MidpointRounding.AwayFromZero);
            return GrandTotal;
        }

        public void MethodOfPayment()
        {

            Console.Clear();


            Console.WriteLine("Thank you for your order! One second while we fetch your total...");

            Console.WriteLine($"Subtotal: ${NumberToDollarFormat.Execute(SubTotal)}");
            Console.WriteLine($"Tax: ${NumberToDollarFormat.Execute(SalesTaxTotal)}");
            Console.WriteLine($"Grand Total: ${NumberToDollarFormat.Execute(GrandTotal)}");
            Console.WriteLine();

            Console.WriteLine("Please select a method of payment (enter a number): " +
                "\n [1] Credit Card" +
                "\n [2] Cash" +
                "\n [3] Check");
            string readingInput = Console.ReadLine();
            
            
            //validating input with an enum try parse
            
            bool isInvalidInput = true;
            //While the input is invalid this loop will continue to run
            while (isInvalidInput)
            {
                if (Enum.TryParse<PaymentSelection>(readingInput, out PaymentSelection userPaymentSelection))
                {
                    switch (userPaymentSelection)
                    {
                        case PaymentSelection.CreditCard:
                            Console.Clear();
                            CreditCard userCreditCard = new CreditCard();
                            userCreditCard.Pay(GrandTotal);
                            Receipt userReceipt = new Receipt(GrandTotal, SubTotal, userShoppingCart.ItemstoPurchase);
                            userReceipt.PrintReceipt();
                            Console.WriteLine("Thank you for your payment from the following credit card");
                            Console.WriteLine("Payment is processed and approved");
                            userCreditCard.printCardInfo();
                            return;

                        case PaymentSelection.Cash:
                            Console.Clear();
                            Cash userCash = new Cash();
                            userCash.Pay(GrandTotal);
                            Receipt cashUserReceipt = new Receipt(GrandTotal, SubTotal, userShoppingCart.ItemstoPurchase);
                            cashUserReceipt.PrintReceipt();
                            userCash.PrintCashInfo();
                            return;

                        case PaymentSelection.Check:
                            Console.Clear();
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
                else
                {
                    Console.WriteLine("ERROR invalid input please enter again: ");
                    Console.WriteLine("Please selece a method of payment [Select 1-3]: " +
                "\n [1] Credit Card" +
                "\n [2] Cash" +
                "\n [3] Check" +
                "\n Enter x to return to the main menu");
                    readingInput = Console.ReadLine();
                    if (readingInput == "x")
                    {
                        StoreApp takeBackToMenu = new StoreApp();
                        takeBackToMenu.RunStore();
                    }
                }
               



            }


        }

        
    }
}
