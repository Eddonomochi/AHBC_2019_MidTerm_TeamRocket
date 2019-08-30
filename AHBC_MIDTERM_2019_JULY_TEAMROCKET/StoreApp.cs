using System;
using System.Collections.Generic;
using System.IO;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    class StoreApp
    {
        //var menu = new Menu() { };
        bool isNotMenuChoice;
        IntegerValidator intergerValidator = new IntegerValidator { };
        bool isValid;
        bool isShoppingAgain;
        int startMenuChoice = 0;
        int shoppingMenuChoice = 0;
        string initalUserInput = "";
        string nextChoiceAfterTransaction = "";
        public ShoppingCart usersCart = new ShoppingCart();
        StoreInventory inventoryPull = new StoreInventory();




        public void RunStore()
        {



            do
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to B#, your number one stop for the latest in digital fashion! \nSelect below from the following options:\n");
                Console.WriteLine("[1] Shop \n[2] About \n[3] Exit");

                initalUserInput = Console.ReadLine();
                do
                {
                    if (IntegerValidator.Validate(initalUserInput))
                    {
                        startMenuChoice = int.Parse(initalUserInput);
                        isValid = true;
                    }
                    else
                    {
                        Console.Clear();
                        menuOptions();
                        initalUserInput = Console.ReadLine();

                        isValid = false;
                    }


                } while (!isValid);


                switch (startMenuChoice)
                {
                    case 1:

                        do
                        {
                            Console.Clear();
                            ShoppingMenu.RunShoppingMenu(inventoryPull, usersCart);
                            Console.Clear();
                            double userSubTotal = usersCart.calculateSubtotal(usersCart.ItemstoPurchase);
                            Payment userPayment = new Payment(userSubTotal, usersCart);
                            userPayment.CalculatedSalesTaxTotal();
                            double grandTotal = userPayment.CalculatedGrandTotal();
                            userPayment.MethodOfPayment();
                            //Receipt userReceipt = new Receipt(grandTotal, userSubTotal, usersCart.ItemstoPurchase);
                            //userReceipt.PrintReceipt();

                            inventoryPull.GenerateStoreInventory(usersCart);
                            StoreInventory.UpdateInventoryDatabase(inventoryPull);
                            usersCart = new ShoppingCart();
                            Console.WriteLine("\nWould Like make another transaction or head to the main menu?\n");
                            Console.WriteLine("[1] New Transaction \n[2] Main Menu\n");

                            nextChoiceAfterTransaction = Console.ReadLine();
                            do
                            {

                                if (IntegerValidator.Validate(nextChoiceAfterTransaction))
                                {
                                    shoppingMenuChoice = int.Parse(nextChoiceAfterTransaction);
                                    isValid = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    menuOptions();
                                    nextChoiceAfterTransaction = Console.ReadLine();

                                    isValid = false;
                                }
                            } while (!isValid);

                            if (shoppingMenuChoice == 1)
                            {
                                isShoppingAgain = true;
                            }
                            else
                            {
                                isShoppingAgain = false;
                            }



                        } while (isShoppingAgain);
                        isNotMenuChoice = true;
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nB# is a contemporary clothing store serving all of the latest fashion " +
                            "for women, men, and children. We carry a vast selection of clothing, shoes, accessories, and jewelry. " +
                            "Whether you’re shopping for an amazing pair of shoes or the perfect outfit for an event, remember to always BE SHARP!\n");

                        Console.WriteLine("Acceptable forms of payment include cash, credit card, or check only.\n");
                        Console.Write("Press 'Enter' to return to main menu...");
                        Console.ReadLine();

                        Console.Clear();

                        isNotMenuChoice = true;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Thank you and B#!");
                        isNotMenuChoice = false;
                        break;

                    default:
                        Console.Clear();
                        Console.Write("Not a valid option. ");

                        isNotMenuChoice = true;
                        break;
                }

            } while (isNotMenuChoice);


            StoreInventory.ResetInventoryDatabase(inventoryPull);
            //    ^^^^^^^^^^^^^^^^^^
            //I added this in case we need to reset the inventory when we close the program. 
            //Idk if we want this, but it's here just in case.

        }

        public static void menuOptions()
        {

            Console.WriteLine("Please, select below from the following options:\n");
            Console.WriteLine("[1] Shop \n[2] About \n[3] Exit");

        }




    }
}