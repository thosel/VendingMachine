using Xunit;

namespace VendingMachine.Tests
{
    /// <summary>
    /// The test class for the beverage class.
    /// </summary>
    public class BeverageShould
    {
        private Beverage _sut;

        /// <summary>
        /// Initializes a beverage instance to be the system under test.
        /// </summary>
        public BeverageShould()
        {
            _sut = new Beverage("Beverage", "Information", 10);
        }

        /// <summary>
        /// Asserts that the beverage returns the correct use message.
        /// </summary>
        [Fact]
        public void ReturnCorrectUseMessage()
        {
            string useMessage = _sut.Use();
            Assert.Equal("The Beverage is being drunk.", useMessage);
        }

    }
}
