using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class Cash 
    {
        double cashGiven, change;
        public void Pay(double total)
        {

            Console.Clear();
            Console.WriteLine($"Your total is: ${NumberToDollarFormat.Execute(total)}, Please enter how much cash you will be recieved: ");
            cashGiven = CashReceived();

            //Console.WriteLine($"Your total is: {total}, Please enter how much cash you will be giving: ");
            //cashGiven = CashReceived();

            
            while (cashGiven < total)
            {
                if (cashGiven < total)
                {
                    Console.Clear();
                    Console.WriteLine("I apologize, however the funds provided are insufficient.");
                }
                Console.WriteLine($"Your total is: ${NumberToDollarFormat.Execute(total)}, Please enter how much cash will be recieved: ");
                cashGiven = CashReceived();

                
            }
            if (cashGiven >= total)
            {
                Console.Clear();
                change = cashGiven - total;
                Console.WriteLine($"Total Change: $" + NumberToDollarFormat.Execute(change));
               
            }
        }

        private double CashReceived()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double cashResult))
                {
                    return cashResult;
                }
                Console.WriteLine("Input Error. Please try again: ");
            }
        }

        public void PrintCashInfo()
        {
            Console.WriteLine("Thank you for your cash payment");
            Console.WriteLine($"Cash given: ${NumberToDollarFormat.Execute(cashGiven)}");
            Console.WriteLine($"Change: ${NumberToDollarFormat.Execute(change)}");
        }


    }
}
    

    
    


