using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    class NumberToDollarFormat
    {
        public static int integerInput { get; set; }
        public static double doubleInput { get; set; }

        public static string Execute(double inputDouble)
        {
            doubleInput = inputDouble;
            string dollarOutput = "";

            dollarOutput = string.Format("{0:#,##0.00}", doubleInput);


            return dollarOutput;

        }

        public static string Execute(int inputInteger)
        {
            integerInput = inputInteger;
            string dollarOutput = "";

            dollarOutput = string.Format("{0:#.00}", integerInput);


            return dollarOutput;

        }






    }
}
