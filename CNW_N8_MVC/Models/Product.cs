using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_N8_MVC.Models
{
    public class Product
    {
        string name;
        string sell_price;
        string price;
        string status_checking;

        public Product(string name, string sell_price, string price, string status_checking)
        {
            this.name = name;
            this.sell_price = sell_price;
            this.price = price;
            this.status_checking = status_checking;
        }

        public string Name { get => name; set => name = value; }
        public string Sell_price { get => sell_price; set => sell_price = value; }
        public string Price { get => price; set => price = value; }
        public string Status_checking { get => status_checking; set => status_checking = value; }
    }
}