using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Snack : AbstractProduct
    {
        public Snack(int ID, int Price, string Title) : base(ID, Price, Title)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Eating {0} ...",Title);
        }
    }
}
