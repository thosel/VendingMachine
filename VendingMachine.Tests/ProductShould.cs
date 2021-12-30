using System;
using Xunit;

namespace VendingMachine.Tests
{
    /// <summary>
    /// The test class for the product class.
    /// </summary>
    public class ProductShould
    {
        private Product _sut;

        /// <summary>
        /// Initializes a product instance to be the system under test.
        /// </summary>
        public ProductShould()
        {
            _sut = new Candy("Product", "Information", 10);
        }

        /// <summary>
        /// Asserts that a product is initialized with the correct values.
        /// </summary>
        [Fact]
        public void BeInitializedCorrectly()
        {
            Assert.Equal("Product", _sut.Name);
            Assert.Equal("Information", _sut.Information);
            Assert.Equal(10, _sut.Price);
        }

        /// <summary>
        /// Asserts that an exception is thrown when initializing the product with
        /// a negative price.
        /// </summary>
        [Fact]
        public void ThrowExceptionWhenPriceIsBelowZero()
        {
            Exception exception = Assert.Throws<Exception>(() => new Candy("Product", "Information", -1));
            Assert.Equal("The price can not be less than zero!", exception.Message);
        }

        /// <summary>
        /// Asserts that the product returns the correct use message.
        /// </summary>
        [Fact]
        public void ReturnCorrectUseMessage()
        {
            string useMessage = _sut.Use();
            Assert.Equal("The product is being used.", useMessage);
        }
    }
}
