using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class AbstractProduct
    {
        
        public int ID { get; set; }
        
        public int Price { get; set; }
        public string Title { get; set; }

        public AbstractProduct(int ID, int Price, string Title)
        { 
            this.ID = ID;
            this.Price = Price;
            this.Title = Title;
        }

        public void Examine()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return String.Format("#{0} \t {1} | {2}kr ", ID, Title, Price);
        }

        public abstract void Use();

    }
}
