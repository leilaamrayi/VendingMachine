using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class SoftDrink : AbstractProduct
    {
        public SoftDrink(int ID, int Price, string Title) : base(ID, Price, Title)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Drinking {0} ...", Title);
        }
    }
}
