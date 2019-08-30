using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{

    public class Check 
    {
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }


        public void Pay(double total)
        {
            Console.WriteLine($"Total: ${NumberToDollarFormat.Execute(total)}\n"); //might not need based on how user interface is set up

            Console.WriteLine("Check Number:\n");     //validation
            AccountNumber = ValidateCheckNumber(Console.ReadLine());

            Console.WriteLine("Routing Number:\n");     //validation
            RoutingNumber = ValidateRouteNumber(Console.ReadLine());

            Console.WriteLine("Your transaction has been processed.");

        }
        public void PrintCheckInfo()
        {
            string accountStars = "";
            string routingStars = "";
            for (int i = 0; i < AccountNumber.Length-4; i++)
            {
                accountStars += "*";
            }
            for (int i = 0; i < RoutingNumber.Length - 4; i++)
            {
                routingStars += "*";
            }

            string accountLastFour = "";
            for (int i = 4; i > 0; i--)
            {
                accountLastFour += AccountNumber[AccountNumber.Length - i];
            }

            string routingLastFour = "";
            for (int i = 4; i > 0; i--)
            {
                routingLastFour += RoutingNumber[RoutingNumber.Length - i];
            }



            Console.WriteLine("Thank you for the check payment");
            Console.WriteLine($"Check Account Number: {accountStars + accountLastFour}");
            Console.WriteLine($"Check Routing Number: {routingStars + routingLastFour}");
        }

        private string ValidateRouteNumber(string routeNum)
        {
            Regex rgx = new Regex(@"^(\w[0-9]{8})$");

            if (rgx.IsMatch(routeNum))
            {
                return routeNum;
            }
            else
            {
                do
                {


                    Console.WriteLine("This is not a valid routing number. Please re-enter.");
                    Console.WriteLine("\nRouting Number:");
                    routeNum = (Console.ReadLine());

                }
                while (!rgx.IsMatch(routeNum));

                return routeNum;

            }
        }

        private string ValidateCheckNumber(string checkNum)
        {
            Regex rgx = new Regex(@"^(\w[0-9]{9,11})$");

            if (rgx.IsMatch(checkNum))
            {
                return checkNum;
            }
            else
            {
                do
                {


                    Console.WriteLine("This is not a valid check number. Please re-enter.");
                    Console.WriteLine("\nCheck Number:");
                    checkNum = (Console.ReadLine());

                }
                while (!rgx.IsMatch(checkNum));

                return checkNum;

            }

        }

    }

}
