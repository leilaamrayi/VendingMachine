using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ProductDatabase
    {
        public static List<AbstractProduct> GetAllProducts()
        {
            List<AbstractProduct> products = new List<AbstractProduct>();

            products.Add(new SoftDrink(10, 11, "Coca Cola"));
            products.Add(new SoftDrink(11, 15, "Coca Cola Zero"));

            products.Add(new Drink(20, 35, "Mariestad Lager"));
            products.Add(new Drink(21, 37, "Carlsberg Pinsler"));
            products.Add(new Drink(22, 30, "Kopparberg Apple Cider"));
            products.Add(new Drink(23, 30, "Kopparberg Pear Cider"));

            products.Add(new Snack(30, 25, "Peanuts"));
            products.Add(new Snack(31, 25, "Spicy Peanuts"));
            products.Add(new Snack(32, 55, "Chicken Wrap"));
            products.Add(new Snack(33, 45, "Cheese & Ham Sandwich"));

            return products;
        }
    }
 
}
