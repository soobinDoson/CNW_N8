using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_N8_MVC.Models
{
    [Serializable]
    public class CartItem {
        private Product product;
        private int quantity;

        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }

    public class Cart
    {
        static List<CartItem> lineCollections = new List<CartItem>();

        public void AddItemHotel(hotel hotel, int quantity)
        {
            CartItem line = lineCollections.Where(p => p.Product.Name == hotel.hotel_name).FirstOrDefault();
            if(line == null)
            {
                var prod = new Product(hotel.hotel_name, hotel.sell_price.ToString(), hotel.price.ToString(), "hotel");

                lineCollections.Add(new CartItem(prod, quantity));
            }
            else
            {
                line.Quantity += quantity;
            }
            
        }
        public void AddItemHomestay(homestay homeStay, int quantity)
        {
            CartItem line = lineCollections.Where(p => p.Product.Name == homeStay.homestay_name).FirstOrDefault();
            if (line == null)
            {
                var prod = new Product(homeStay.homestay_name, homeStay.sell_price.ToString(), homeStay.price.ToString(), "homestay");
                lineCollections.Add(new CartItem(prod, quantity));
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLineProduct(Product product)
        {
            lineCollections.RemoveAll(p => p.Product.Name == product.Name);
        }
        
        public IEnumerable<CartItem> lines { get { return lineCollections; } }
    }
}