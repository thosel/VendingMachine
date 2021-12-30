using Xunit;

namespace VendingMachine.Tests
{
    /// <summary>
    /// The test class for the candy class.
    /// </summary>
    public class CandyShould
    {
        private Candy _sut;

        /// <summary>
        /// Initializes a candy instance to be the system under test.
        /// </summary>
        public CandyShould()
        {
            _sut = new Candy("Candy", "Information", 10);
        }

        /// <summary>
        /// Asserts that the candy returns the correct use message.
        /// </summary>
        [Fact]
        public void ReturnCorrectUseMessage()
        {
            string useMessage = _sut.Use();
            Assert.Equal("The Candy is being eaten.", useMessage);
        }
    }
}
