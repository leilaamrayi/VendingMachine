using VendingMachine;

namespace VendingMachineTest
{
    public class VendingMachineCases
    {
        [Fact]
        public void VM_InsertMoneyShouldWork()
        {
            IVending vending = new VendingMachine.VendingMachine();
            Assert.True(vending.InsertMoney(100)); // 100 is an accepted note
            Assert.False(vending.InsertMoney(200)); // 200 is NOT an accepted note
        }

        [Fact]
        public void VM_PurchaseShouldFailOnInvalidProductID()
        {
            int invalidProductID = 1002;
            List<AbstractProduct> products = ProductDatabase.GetAllProducts();
            // make sure such product does not exist in DB and VendingMachine
            Assert.Null(products.Find(p => p.ID == invalidProductID));
            
            IVending vending = new VendingMachine.VendingMachine(products);
            Assert.Null(vending.Purchase(invalidProductID));
        }

        [Fact]
        public void VM_PurchaseShouldFailOnInsufficientBalance()
        {
            List<AbstractProduct> products = ProductDatabase.GetAllProducts();
            IVending vending = new VendingMachine.VendingMachine(products);
            int productID = products.FirstOrDefault().ID;
            Assert.Null(vending.Purchase(productID));
        }

        [Fact]
        public void VM_PurchaseShouldWorkOnSufficientBalance()
        {
            List<AbstractProduct> products = ProductDatabase.GetAllProducts();
            IVending vending = new VendingMachine.VendingMachine(products);
            int productID = products.FirstOrDefault().ID;
            vending.InsertMoney(100);
            Assert.NotNull(vending.Purchase(productID));
        }

        [Fact]
        public void VM_EndTransactionShouldReturnNullIfBalanceIsZero()
        {
            IVending vending = new VendingMachine.VendingMachine();
            Assert.Null(vending.EndTransaction());
        }

        [Fact]
        public void VM_EndTransactionShouldReturnNonNullIfChangeExists()
        {
            List<AbstractProduct> products = ProductDatabase.GetAllProducts();
            IVending vending = new VendingMachine.VendingMachine(products);
            int productID = products.FirstOrDefault().ID;
            vending.InsertMoney(100);
            vending.Purchase(productID);
            Assert.NotNull(vending.EndTransaction());
        }

    }
}