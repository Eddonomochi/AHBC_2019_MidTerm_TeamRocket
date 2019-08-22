﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    class ShoppingMenu
    {
        string initialUserInput = "";
        bool isValid, isNotMenuChoice;
        IntegerValidator intergerValidator = new IntegerValidator();
        int startMenuChoice;


        public void Run()
        {

            menuOptions();


            initialUserInput = Console.ReadLine();

            do
            {
                do
                {
                    if (intergerValidator.Validate(initialUserInput))
                    {
                        startMenuChoice = int.Parse(initialUserInput);
                        isValid = true;
                    }
                    else
                    {

                        menuOptions();
                        initialUserInput = Console.ReadLine();

                        isValid = false;
                    }


                } while (!isValid);


                if (startMenuChoice > 0 && startMenuChoice < 5)
                {

                    //categoryselector( );
                    isNotMenuChoice = false;
                    
                }
                else
                {

                    Console.Clear();
                    Console.Write("Not a valid option. ");
                    menuOptions();
                    initialUserInput = Console.ReadLine();
                    isNotMenuChoice = true;
                    
                }

            } while (isNotMenuChoice);





            Console.Read();






        }


        public void menuOptions()
        {
            Console.WriteLine("Please selecet for the following categories:\n");
            Console.WriteLine("[1] Clothiging\n[2] Accessories\n[3] Shoes\n[4] Outerwear\n");

        }


    }
}
