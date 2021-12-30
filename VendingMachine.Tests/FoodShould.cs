using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VendingMachine.Tests
{
    /// <summary>
    /// The test class for the food class.
    /// </summary>
    public class FoodShould
    {
        private Food _sut;

        /// <summary>
        /// Initializes a food instance to be the system under test.
        /// </summary>
        public FoodShould()
        {
            _sut = new Food("Food", "Information", 10);
        }

        /// <summary>
        /// Asserts that the food returns the correct use message.
        /// </summary>
        [Fact]
        public void ReturnCorrectUseMessage()
        {
            string useMessage = _sut.Use();
            Assert.Equal("The Food is being eaten.", useMessage);
        }
    }
}
