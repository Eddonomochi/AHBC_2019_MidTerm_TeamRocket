using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class CreditCard 
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVVCode { get; set; }
        public CardTypes cardEnum { get; set; }

        public enum CardTypes
        {
            VISA = 1,
            MASTER = 2,
            DISC = 3,
            AMEX = 4
        };


        public void Pay(double total)
        {
            Console.Clear();
            Console.WriteLine($"Total: ${NumberToDollarFormat.Execute(total)}\n"); //might not need based on how user interface is set up
            Console.WriteLine("Please choose a Card Type: \n[1] VISA \n[2] MASTER \n[3] DISC \n[4] AMEX");


            while (true)
            {

                string cardType = Console.ReadLine();           // USER VALIDATION, possibly use TryCatch 
                bool ignoreCase = true;

                if (Enum.TryParse<CardTypes>(cardType, ignoreCase, out CardTypes result))
                {
                    cardEnum = result;
                    if (cardEnum == CardTypes.VISA | cardEnum == CardTypes.MASTER | cardEnum == CardTypes.DISC)
                    {
                        Console.Write("\nPlease enter the credit card number(no dashes or spaces): ");
                        CardNumber = ValidateCardNumber1(Console.ReadLine());


                        Console.Write("\nExpiration Date (MM/YY) or (MM/YYYY): ");
                        ExpirationDate = ValidateExpDate(Console.ReadLine());


                        Console.Write("\nCVV: ");
                        CVVCode = ValidateCVVCode1(Console.ReadLine());


                        Console.WriteLine("Your transaction has been processed.");
                        break;


                    }
                    else if (cardEnum == CardTypes.AMEX)
                    {

                        Console.Write("\nPlease enter the credit card number(no dashes or spaces): ");
                        CardNumber = ValidateCardNumber2(Console.ReadLine());


                        Console.Write("\nExpiration Date (MM/YY) or (MM/YYYY): ");
                        ExpirationDate = ValidateExpDate(Console.ReadLine());


                        Console.Write("\nCVV:");
                        CVVCode = ValidateCVVCode2(Console.ReadLine());


                        Console.WriteLine("Your transaction has been processed.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid card type. Please try again.");
                        continue;
                    }
                }

            }

        }
        //might have to add a print creditcard information
        private string ValidateCVVCode1(string cvvNum)
        {
            Regex cvv1 = new Regex(@"^(\w[0-9]{2})$");

            if (cvv1.IsMatch(cvvNum))
            {
                return cvvNum;
            }
            else
            {
                do
                {
                    Console.WriteLine("This is not a valid CVV code. Please re-enter.");
                    Console.WriteLine("\nCVV Code: ");
                    cvvNum = (Console.ReadLine());

                }
                while (!cvv1.IsMatch(cvvNum));

                return cvvNum;

            }
        }

        private string ValidateCVVCode2(string cvvNum)
        {
            Regex cvv2 = new Regex(@"^(\w[0-9]{3})$");

            if (cvv2.IsMatch(cvvNum))
            {
                return cvvNum;
            }
            else
            {
                do
                {
                    Console.WriteLine("This is not a valid CVV code. Please re-enter.");
                    Console.WriteLine("\nCVV Code: ");
                    cvvNum = (Console.ReadLine());

                }
                while (!cvv2.IsMatch(cvvNum));

                return cvvNum;

            }

        }



        private string ValidateExpDate(string expDate)
        {
            Regex rgx = new Regex(@"^(1[0-2]|0[1-9]|\d)\/([2-9]\d[1-9]\d|[1-9]\d)$");

            if (rgx.IsMatch(expDate))
            {
                return expDate;
            }
            else
            {
                do
                {
                    Console.WriteLine("This is not a valid expiration date. Please re-enter.");
                    Console.Write("\nExpiration Date: ");
                    expDate = (Console.ReadLine());

                }
                while (!rgx.IsMatch(expDate));

                return expDate;

            }

        }


        public string ValidateCardNumber1(string cardNum)
        {
            Regex rgx = new Regex(@"^(\w[0-9]{15})$");

            if (rgx.IsMatch(cardNum))
            {
                return cardNum;
            }
            else
            {
                do
                {
                    Console.WriteLine("This is not a valid card number. Please re-enter.");
                    Console.Write("\nCard Number: ");
                    cardNum = (Console.ReadLine());

                }
                while (!rgx.IsMatch(cardNum));

                return cardNum;

            }

        }

        public string ValidateCardNumber2(string cardNum)
        {
            Regex rgx = new Regex(@"^(\w[0-9]{14})$");

            if (rgx.IsMatch(cardNum))
            {
                return cardNum;
            }
            else
            {
                do
                {
                    Console.WriteLine("This is not a valid card number. Please re-enter.");
                    Console.Write("\nCard Number: ");
                    cardNum = (Console.ReadLine());

                }
                while (!rgx.IsMatch(cardNum));

                return cardNum;

            }


        }
        public void printCardInfo()
        {
            string creditStars = "";
            for (int i = 0; i < CardNumber.Length-4; i++)
            {
                creditStars += "*";
            }
            string creditLastFour = "";
            for (int i = 4; i > 0 ; i--)
            {
                creditLastFour += CardNumber[CardNumber.Length-i];
            }
            Console.WriteLine($"Card Type: {cardEnum}");
            Console.WriteLine($"Card Number: {creditStars + creditLastFour}");
            Console.WriteLine($"Experation Date: {ExpirationDate}");
            //Console.WriteLine($"CVV code: {CVVCode}"); //Should this be on the reciept?
        }
    }
}








