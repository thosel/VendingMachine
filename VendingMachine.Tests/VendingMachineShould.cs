using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachine.Tests
{
    /// <summary>
    /// The test class for the vending machine class.
    /// </summary>
    public class VendingMachineShould
    {
        private readonly VendingMachine _sut;
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a vending machine instance to be the system under test.
        /// The product list is also being initialized with different products.
        /// </summary>
        public VendingMachineShould()
        {
            _sut = new VendingMachine();
            _products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                _products.Add(new Candy($"Candy", $"Candy information", 10));
                _products.Add(new Beverage($"Beverage", $"Beverage information", 10));
                _products.Add(new Food($"Food", $"Food information", 10));
            }
        }

        /// <summary>
        /// Inserts the products in the product list into the vending machine.
        /// </summary>
        private void InsertProducts()
        {
            foreach (var product in _products)
            {
                _sut.InsertProduct(product);
            }
        }

        /// <summary>
        /// Asserts that an exception is thrown when a null value is passed as an argument 
        /// when inserting a product.
        /// </summary>
        [Fact]
        public void InsertProductAndThrowException()
        {
            Exception thrownException = Assert.Throws<Exception>(() => _sut.InsertProduct(null));
            Assert.Equal("No product was inserted.", thrownException.Message);
        }

        /// <summary>
        /// Asserts that the money inserted is actually inserted.
        /// </summary>
        /// <param name="moneyToInsert">The money to insert</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void InsertMoney(int moneyToInsert)
        {
            _sut.InsertMoney(moneyToInsert);

            Assert.Equal(moneyToInsert, _sut.InsertedMoney);
        }

        /// <summary>
        /// Asserts that an exception is thrown when a faulty denomination is inserted.
        /// </summary>
        /// <param name="moneyToInsert">The money to insert</param>
        [Theory]
        [InlineData(347)]
        [InlineData(-1)]
        [InlineData(0)]
        public void InsertMoneyAndThrowException(int moneyToInsert)
        {
            Exception thrownException = Assert.Throws<Exception>(() => _sut.InsertMoney(moneyToInsert));
            Assert.Equal("You inserted money in the wrong denomination.", thrownException.Message);
        }

        /// <summary>
        /// Asserts that all the products in the vending machine is purchased and 
        /// that each purchase returned the correct product.
        /// </summary>
        [Fact]
        public void PurchaseExistingProducts()
        {
            InsertProducts();
            _sut.InsertMoney(100);
            _sut.InsertMoney(100);
            _sut.InsertMoney(100);

            foreach (var product in _products)
            {
                Product purchaseProduct = _sut.Purchase(product.Name);

                Assert.Equal(product.Name, purchaseProduct.Name);
            }
        }

        /// <summary>
        /// Asserts that an exception is thrown when trying to purchase a non-existing product or
        /// if the product has a higher price than the money that is inserted.
        /// </summary>
        /// <param name="productName">The name of the product to buy</param>
        /// <param name="moneyToInsert">The money to insert</param>
        /// <param name="excpectedExceptionMessage">The expected exception message</param>
        [Theory]
        [InlineData("Product that do not exist", 10, "The product choice could not be found.")]
        [InlineData("Candy", 0, "Not enough money inserted to buy the product.")]
        public void PurchaseAndThrowException(string productName, int moneyToInsert, string excpectedExceptionMessage)
        {
            InsertProducts();

            if (moneyToInsert != 0)
            {
                _sut.InsertMoney(moneyToInsert);
            }

            Exception thrownException = Assert.Throws<Exception>(() => _sut.Purchase(productName));
            Assert.Equal(excpectedExceptionMessage, thrownException.Message);
        }

        /// <summary>
        /// Asserts that the money currently inserted is actually returned when the
        /// transaction is ended.
        /// </summary>
        [Fact]
        public void EndTransactionCorrectly()
        {
            _sut.InsertMoney(100);

            int moneyReturned = _sut.EndTransaction();

            Assert.Equal(100, moneyReturned);
        }
    }
}
