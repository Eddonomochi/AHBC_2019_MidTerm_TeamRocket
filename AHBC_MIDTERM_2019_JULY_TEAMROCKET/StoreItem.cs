using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class StoreItem : IItem
    {
        public string NameOfItem { get; set; }
        public string ItemCategory { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }

         

        
        //function to read text file
        public List<string> FileReader() //returns entire file in a list
        {
            
       //var location = $"{AppDomain.CurrentDomain.BaseDirectory}../../../ItemsFile/Items.txt";
            List<string> linesOfTextFile = new List<string>();  //creating new list to store the text file
            using (var reader = new StreamReader(FileLocation.location))  //opening file
            {
                var entireFile = reader.ReadToEnd();  //variable to store the entire file so we can edit
                var lineArray = entireFile.Split("\r\n");  //storing file into a string array

                foreach (var line in lineArray)  //looping through the line array
                {
                    linesOfTextFile.Add(line);  //adding each line of the text file to the lines list

                }
            }
            return linesOfTextFile;  //returning the completed list whole text file has been read and stored
        }

      

        public StoreItem ReturnStoreItem(string itemLine)  //passing in a line from the list to create an item with
        {
            string itemProperties;  //local variable to store the line from the list
            StoreItem itemCreator = new StoreItem();  //Variable to create our new item 
            itemProperties = itemLine;  //stores the line passed into the function
            IList<string> item1 = new List<string>() { }; //list variable to store each property of this item
            double price = 0; //used for parsing the price into a double
            int quantity = 0; //used for parsing the quantity into an int
            //Going through list and splitting on comma because that is how they are in the text file
            foreach (var property in itemProperties.Split(','))
            {

                item1.Add(property);  //adding item property to list

            }
            //storing each property into a store item
            itemCreator.NameOfItem = item1[0];
            string temp = item1[1];
            quantity = int.Parse(temp);
            //itemCreator.ItemQuantity = item1[1];
            itemCreator.ItemQuantity = quantity;
            string temp2 = item1[2];
            price = double.Parse(temp2);
            itemCreator.ItemPrice = price;
            itemCreator.ItemCategory = item1[3];

            //returning created item
            return itemCreator;
        }




    }
}
