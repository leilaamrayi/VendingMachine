using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Drink : AbstractProduct
    {
        public Drink(int ID, int Price, string Title) : base(ID, Price, Title)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Drinking {0} ...",Title);
        }
    }
}
