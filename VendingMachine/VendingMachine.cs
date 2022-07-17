using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        private int[] denominations = new int[] { 1000,500,100,50,20,10,5,1 };
        private decimal balance = 0;
        private List<AbstractProduct> products = new List<AbstractProduct>();

        public VendingMachine(List<AbstractProduct> products)
        {
            this.products = products;
        }

        public VendingMachine()
        {
            this.products = ProductDatabase.GetAllProducts();
        }

        public bool InsertMoney(int value)
        {
            if (!denominations.Contains(value))
            {
                return false;
            }
            else
            {
                balance += value;
                return true;
            }
        }

        public AbstractProduct Purchase(int productID)
        {
            var p = products.Find(p => p.ID == productID);
            if (p == null)
            {
                Console.WriteLine("Product with such ID not found. Please try again.");
                return null;
            }
            if (p.Price > balance)
            {
                Console.WriteLine("Not enough balance for this product! Please choose a cheaper one.");
                return null;
            }

            balance -= p.Price;
            Console.WriteLine("Please take your product.");
            return p;

        }

        public void ShowAll()
        {
            Console.WriteLine("\r\nSoft Drinks\r\n---------------");
            products.FindAll(p => p is SoftDrink).ForEach(p => { p.Examine(); });

            Console.WriteLine("\r\nDrinks\r\n---------------");
            products.FindAll(p => p is Drink).ForEach(p => { p.Examine(); });

            Console.WriteLine("\r\nSnacks\r\n---------------");
            products.FindAll(p => p is Snack).ForEach(p => { p.Examine(); });

        }

        public IDictionary<string, int> EndTransaction()
        {
            if (balance == 0) 
            {
                Console.WriteLine("Have a nice day!");
                return null;
            }

            var changeDic = CalculateChange();
            
            Console.WriteLine("\r\nHere is your change:");
            foreach (KeyValuePair<string, int> entry in changeDic)
            {
                Console.WriteLine("{0} {1}", entry.Value, entry.Key);
            }
            balance = 0;
            return changeDic;
        }

        private IDictionary<string, int> CalculateChange()
        {
            IDictionary<string, int> changeDic = new Dictionary<string, int>();

            foreach (var note in denominations)
            {
                int count = (int)(balance / note);
                balance -= count * note;
                if (count == 0) { continue; }
                string noteName = note + "kr";
                changeDic.Add(noteName, count);
            }

            return changeDic;
        }
    }
}
