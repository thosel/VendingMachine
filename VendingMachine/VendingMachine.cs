using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    /// <summary>
    /// Describes a vending machine.
    /// </summary>
    public class VendingMachine : IVending
    {
        private readonly int[] _denominations;
        private int _insertedMoney;
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes the vending machine with the correct denominations, a product list and
        /// also sets the inserted money to be zero.
        /// </summary>
        public VendingMachine()
        {
            _denominations = new[] {1, 5, 10, 20, 50, 100, 500, 1000};
            InsertedMoney = 0;
            _products = new List<Product>();
        }

        /// <summary>
        /// Stores the inserted money.
        /// </summary>
        public int InsertedMoney
        {
            get { return _insertedMoney; }
            private set { _insertedMoney = value; }
        }

        /// <summary>
        /// Inserts a product into the vending machine.
        /// </summary>
        /// <param name="product">The product to insert</param>
        public void InsertProduct(Product product)
        {
            if(isProductInsertable(product))
            {
                _products.Add(product);
            }
        }

        /// <summary>
        /// Validates if a product is insertable by supplying it.
        /// </summary>
        /// <param name="product">The product to insert</param>
        /// <returns>Returns true if the product is insertable, otherwise an exception is thrown</returns>
        private bool isProductInsertable(Product product)
        {
            return (product == null) ? throw new Exception("No product was inserted.") : true;
        }

        /// <summary>
        /// Finds a product that has a certain name.
        /// </summary>
        /// <param name="productName">The desired name of the product</param>
        /// <returns>The product if it was found otherwise null is returned</returns>
        private Product FindProductByName(string productName)
        {
            Product productToReturn = null;

            foreach (var product in _products)
            {
                if (product.Name.Equals(productName))
                {
                    productToReturn = product;
                }
            }

            return productToReturn;
        }

        /// <summary>
        /// Validates if a product is purchable by supplying its name.
        /// </summary>
        /// <param name="productName">The name of the product</param>
        /// <returns>Returns the product if purchable, otherwise an exception is thrown</returns>
        private Product ReturnProductIfPurchable(string productName)
        {
            Product productToPurchase = FindProductByName(productName);

            if (productToPurchase == null)
            {
                throw new Exception("The product choice could not be found.");
            }
            else if (InsertedMoney < productToPurchase.Price)
            {
                throw new Exception("Not enough money inserted to buy the product.");
            }

            return productToPurchase;
        }

        /// <summary>
        /// Validates that the given money is insertable.
        /// </summary>
        /// <param name="moneyToInsert">The money to insert</param>
        /// <returns>Returns the money to insert if insertable, otherwise an exception is thrown</returns>
        private int isMoneyInsertable(int moneyToInsert)
        {
            bool isMoneyToBeInserted = false;

            foreach (var denomination in _denominations)
            {
                if (denomination == moneyToInsert)
                {
                    isMoneyToBeInserted = true;
                }
            }

            if (!isMoneyToBeInserted)
            {
                throw new Exception("You inserted money in the wrong denomination.");
            }

            return moneyToInsert;
        }

        #region IVending

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> moneyToReturn = new Dictionary<int, int>();

            while (InsertedMoney != 0)
            {
                for (int i = _denominations.Length - 1; i >= 0; i--)
                {
                    while (_denominations[i] <= InsertedMoney)
                    {
                        if (moneyToReturn.ContainsKey(_denominations[i]))
                        {
                            moneyToReturn[_denominations[i]]++;
                        }
                        else
                        {
                            moneyToReturn.Add(_denominations[i], 1);
                        }
                        InsertedMoney -= _denominations[i];
                    }
                }
            }

            return moneyToReturn;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public string ShowAll()
        {
            StringBuilder productInventoryPresentation = new StringBuilder();

            Dictionary<string, int> productInventory = new Dictionary<string, int>();
            
            foreach (var product in _products)
            {
                if (productInventory.ContainsKey(product.Examine()))
                {
                    productInventory[product.Examine()]++;
                }
                else
                {
                    productInventory.Add(product.Examine(), 1);
                }
            }

            foreach (var productInventoryItem in productInventory)
            {
                productInventoryPresentation.Append($"{productInventoryItem.Key}");
                productInventoryPresentation.Append("Items left:".PadRight(20));
                productInventoryPresentation.Append($"{productInventoryItem.Value}\n\n");
            }

            return productInventoryPresentation.ToString();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="moneyToInsert"><inheritdoc/></param>
        public void InsertMoney(int moneyToInsert)
        {
            _insertedMoney += isMoneyInsertable(moneyToInsert);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="productName"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public Product Purchase(string productName)
        {
            Product productToPurchase = ReturnProductIfPurchable(productName);

            InsertedMoney -= productToPurchase.Price;
            _products.Remove(productToPurchase);

            return productToPurchase;
        }

        #endregion
    }
}
