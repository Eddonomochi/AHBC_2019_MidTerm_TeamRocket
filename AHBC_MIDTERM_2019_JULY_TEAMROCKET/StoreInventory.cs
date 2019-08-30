using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class StoreInventory: IEnumerable<StoreItem>
    {
        public List<StoreItem> TotalStoreInventory { get; set; }
        private ShoppingCart categoryCart = new ShoppingCart();

        public void GenerateStoreInventory(ShoppingCart tempcart)
        {
            
            categoryCart = tempcart;
            List<StoreItem> StoreInventory = new List<StoreItem>();  //creating list to store and return the store inventory
            StoreItem testItem = new StoreItem(); //Store item creator
            List<string> storeFromTextFile = new List<string>();  //list to grab the store inventory from text file
            storeFromTextFile = testItem.FileReader(); //storing text file

            foreach (var line in storeFromTextFile)  //looping through each line of the list to create store items from each line
            {
                if (line != "") //if the line is not null continue to add store items to the list
                {
                    StoreInventory.Add(testItem.ReturnStoreItem(line));  //adding store items into the store inventory
                }
                else //end of the list
                {
                    break;
                }
                TotalStoreInventory = StoreInventory;
            }

            foreach (var item in TotalStoreInventory)
            {
                foreach (var cartItem in tempcart)
                {
                    if (cartItem.NameOfItem == item.NameOfItem)
                    {

                        if ((item.ItemQuantity -= cartItem.ItemQuantity) <= 0)
                        {
                            item.ItemQuantity = 0;
                        }

                    }
                }
            }

        }
        public StoreItem this[int index]
        {
            get { return TotalStoreInventory[index]; }
            set { TotalStoreInventory.Insert(index, value); }
        }

        public IEnumerator<StoreItem> GetEnumerator()
        {
            if (TotalStoreInventory == null)
            {
                GenerateStoreInventory(categoryCart);
            }

            return TotalStoreInventory.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (!(TotalStoreInventory.Count > 0))
            {
                GenerateStoreInventory(categoryCart);
            }
            return this.GetEnumerator();
        }


        public static void UpdateInventoryDatabase(StoreInventory currentInventory)
        {
            string newInventoryFileString="";
            foreach (StoreItem item in currentInventory)
            {

                newInventoryFileString += item.NameOfItem +",";
                newInventoryFileString += item.ItemQuantity +",";
                newInventoryFileString += item.ItemPrice + ",";
                newInventoryFileString += item.ItemCategory + System.Environment.NewLine;

            }

            File.WriteAllText(FileLocation.location, newInventoryFileString);
        }


        public static void ResetInventoryDatabase(StoreInventory currentInventory)
        {
            string newInventoryFileString = "";
            foreach (StoreItem item in currentInventory)
            {

                newInventoryFileString += item.NameOfItem + ",";
                newInventoryFileString += "25,";
                newInventoryFileString += item.ItemPrice + ",";
                newInventoryFileString += item.ItemCategory + System.Environment.NewLine;

            }

            File.WriteAllText(FileLocation.location, newInventoryFileString);
        }





    }
}
