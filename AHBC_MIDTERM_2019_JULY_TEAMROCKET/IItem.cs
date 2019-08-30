using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    public interface IItem
    {
        string NameOfItem { get; set; }
        string ItemCategory { get; set; }  //Possibly enum?
        int ItemQuantity { get; set; }
        double ItemPrice { get; set; }
    }


}
