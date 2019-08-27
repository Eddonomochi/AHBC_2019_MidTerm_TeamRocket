﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class CategorySelectionApp
    {

        private int userMenuSelection { get; set; }
        public int itemSelection { get; set; }
        public int qtySelection { get; set; }
        public List<string> categories { get; set; }


        string testSelection;
        string testQTY;
        bool isValid;


        List<StoreItem> tempList = new List<StoreItem>();
        StoreItem tempItem = new StoreItem();





        public CategorySelectionApp(int userSelection, List<string> originalCategories)
        {
            userMenuSelection = userSelection;
            categories = originalCategories;

        }

        public void categorySelector(StoreInventory currentInventory, ShoppingCart userCart)
        {
            currentInventory.GenerateStoreInventory(userCart);


            Console.Clear();
            Console.WriteLine("Which item would you like to purchase? (Select from the folowing numbers)");

            int i = 0;
            foreach (var item in currentInventory.TotalStoreInventory)
            {

                if (item.ItemCategory == categories[userMenuSelection - 1])
                {

                    Console.WriteLine($"{i} {item.NameOfItem}\tQTY: {item.ItemQuantity}\tPrice: ${item.ItemPrice}");
                    tempList.Add(item);


                    i++;

                }
            }
            DislayListOfItems(userCart);

        }
        public void DislayListOfItems(ShoppingCart tempcart)
        {
            testSelection = Console.ReadLine();


            ValidItemChoice();

            Console.Write($"How many {tempList[itemSelection].NameOfItem}s would you like to purchase (QTY: {tempList[itemSelection].ItemQuantity}):");

            testQTY = Console.ReadLine();

            ValidQuantityEntered();


            Console.Clear();
            Console.WriteLine($"Great! {qtySelection} {tempList[itemSelection].NameOfItem}{(qtySelection==1 ? "" : "s")} have been added to you shopping cart!\r");
            Console.WriteLine();

            if (qtySelection > 0 )
            {
                tempItem.NameOfItem = tempList[itemSelection].NameOfItem;
                tempItem.ItemPrice = tempList[itemSelection].ItemPrice;
                tempItem.ItemQuantity = qtySelection;
                tempItem.ItemCategory = tempList[itemSelection].ItemCategory;

                tempcart.addToCart(tempItem);

            }

            if (tempcart.Count()>0)
            {
                tempcart.DisplayCart();

            }


        }

        public void ValidQuantityEntered()
        {
            do
            {
                if (IntegerValidator.Validate(testQTY))
                {

                    if (int.Parse(testQTY) >= 0 && int.Parse(testQTY) <= tempList[itemSelection].ItemQuantity)
                    {
                        qtySelection = int.Parse(testQTY);
                        isValid = true;

                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice, please try again.");
                        testQTY = Console.ReadLine();
                        isValid = false;

                    }


                }
                else
                {

                    Console.WriteLine("That is not a valid choice, please try again.");
                    testQTY = Console.ReadLine();
                    isValid = false;


                }
            } while (!isValid);
        }

        public void ValidItemChoice()
        {
            do
            {
                if (IntegerValidator.Validate(testSelection))
                {

                    if (int.Parse(testSelection) >= 0 && int.Parse(testSelection) <= tempList.Count)
                    {
                        itemSelection = int.Parse(testSelection);
                        isValid = true;

                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice, please try again.");
                        testSelection = Console.ReadLine();
                        isValid = false;

                    }


                }
                else
                {

                    Console.WriteLine("That is not a valid choice, please try again.");
                    testSelection = Console.ReadLine();
                    isValid = false;

                }
            } while (!isValid);
        }

    }
}
