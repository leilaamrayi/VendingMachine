namespace VendingMachine
{
    public class Calculator
    {

       

        public static void Main(string[] args)
        {
            
            IVending vending = new VendingMachine();

            while (true)
            {
                Console.WriteLine("\r\nWelcome!");
                vending.ShowAll();
                ReceiveMoney(vending);
                SelectProducts(vending);
                vending.EndTransaction();
                Console.WriteLine("\r\n\r\nPress ENTER to start over...");
                Console.ReadLine();
                Console.Clear();
            }


        }

        private static void SelectProducts(IVending vending)
        {
            Console.WriteLine("\r\n\r\nNow choose your products.");

            while (true)
            {
                Console.WriteLine("Enter product number, or hit ENTER to finish:");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                try
                {
                    int productID = int.Parse(input);
                    var product = vending.Purchase(productID);
                    if (product != null) 
                    {
                        product.Use();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }

            }
        }

        private static void ReceiveMoney(IVending vending)
        {
            Console.WriteLine("\r\n\r\nPlease insert your bank note, or hit ENTER to exit.");
            Console.WriteLine("Values 1,5,10,20,50,100,500,1000 are accepted.");

            while (true)
            {
                // ask the user to deposit notes one by one, one note at a time
                Console.WriteLine("Enter amount here:");
                string? input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                
                try
                {
                    int inputValue = int.Parse(input);
                    if (!vending.InsertMoney(inputValue))
                    {
                        Console.WriteLine("Bank note rejected. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }
                
            }
        }
    } 
}
            
