using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IVending
    {
        void ShowAll();
        AbstractProduct Purchase(int productID);
        bool InsertMoney(int value);
        IDictionary<string, int> EndTransaction();
    }
}
