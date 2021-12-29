using System.Collections.Generic;

namespace VendingMachine
{
    /// <summary>
    /// Interface to use when implementing vending products.
    /// </summary>
    public interface IVending
    {
        /// <summary>
        /// Purchases a product.
        /// </summary>
        /// <param name="productName">The product name</param>
        /// <returns>The product</returns>
        public Product Purchase(string productName);

        /// <summary>
        /// Returns the product inventory.
        /// </summary>
        /// <returns>The product inventory</returns>
        public string ShowAll();

        /// <summary>
        /// Inserts money to use when purchasing products.
        /// </summary>
        /// <param name="moneyToInsert">The money to insert</param>
        public void InsertMoney(int moneyToInsert);

        /// <summary>
        /// Ends the transaction by returning the remaining money.
        /// </summary>
        /// <returns>The remaining money</returns>
        public int EndTransaction();
    }
}
