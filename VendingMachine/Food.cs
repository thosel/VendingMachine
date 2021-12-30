namespace VendingMachine
{
    /// <summary>
    /// Describes a food.
    /// </summary>
    public class Food : Product
    {
        /// <summary>
        /// Initializes the food with a name, information and a price.
        /// </summary>
        /// <param name="name"><inheritdoc cref="Product.Product" path="/param[@name='name']"/></param>
        /// <param name="information"><inheritdoc cref="Product.Product" path="/param[@name='information']"/></param>
        /// <param name="price"><inheritdoc cref="Product.Product" path="/param[@name='price']"/></param>
        public Food(string name, string information, int price) : base(name, information, price){}

        /// <summary>
        /// Returns a use message.
        /// </summary>
        /// <returns>The use message</returns>
        public new string Use()
        {
            return $"The {Name} is being eaten.";
        }
    }
}
