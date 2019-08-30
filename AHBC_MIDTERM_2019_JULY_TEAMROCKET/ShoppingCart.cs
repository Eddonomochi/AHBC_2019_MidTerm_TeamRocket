using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public class ShoppingCart:IEnumerable<StoreItem>
    {
        public List<StoreItem> ItemstoPurchase = new List<StoreItem>();
        public double cartValue { get; set; }
        private bool isAddable { get; set; }


        public void addToCart(StoreItem item)
        {

            isAddable = true;
            foreach (var cartitem in ItemstoPurchase)
            {

                if (cartitem.NameOfItem == item.NameOfItem)
                {
                    cartitem.ItemQuantity += item.ItemQuantity;
                    isAddable = false;

                }
            }

            if (isAddable)
            {
                ItemstoPurchase.Add(item);
            }
            cartValue = 0;
            //calculateSubtotal(ItemstoPurchase);

        }


        public double calculateSubtotal(List<StoreItem> cartList)
        {
            foreach (var item in cartList)
            {
                cartValue += (item.ItemPrice * item.ItemQuantity);

            }
            return cartValue;
        }

        //public void changeCurrentSock(List<StoreItem> currentStock)
        //{
        //    foreach (var item in currentStock)
        //    {
        //        foreach (var cartItem in ItemstoPurchase)
        //        {
        //            if (cartItem.NameOfItem == item.NameOfItem)
        //            {
        //                item.ItemQuantity -= cartItem.ItemQuantity;
        //            }

        //        }
        //    }
        //}

        public StoreItem this[int index]
        {
            get { return ItemstoPurchase[index]; }
            set {ItemstoPurchase.Insert(index,value); }
        }

        public IEnumerator<StoreItem> GetEnumerator()
        {
            return ItemstoPurchase.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void DisplayCart()
        {
            int i = 1;
            Console.WriteLine("So far in your cart you have the following:\r");
            foreach (var item in ItemstoPurchase)
            {
                Console.WriteLine("{0,-20} {1,-10:N1}", $"{i}. {item.NameOfItem}", $"{item.ItemQuantity} x ${NumberToDollarFormat.Execute(item.ItemPrice)} = ${NumberToDollarFormat.Execute(item.ItemPrice*item.ItemQuantity)}");
                i++;
            }
            Console.WriteLine();
        }
    }
}
