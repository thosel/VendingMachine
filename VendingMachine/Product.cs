using System;
using System.Text;

namespace VendingMachine
{
    /// <summary>
    /// Describes a produkt.
    /// </summary>
    public abstract class Product
    {
        private int _price;

        /// <summary>
        /// Initializes the product with a name, information and a price.
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="information">The information</param>
        /// <param name="price">The price</param>
        public Product(string name, string information, int price)
        {
            Name = name;
            Information = information;
            Price = price;
        }

        /// <summary>
        /// Stores the name of the product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Stores the information of the product.
        /// </summary>
        public string Information { get; private set; }

        /// <summary>
        /// Stores the price of the product.
        /// </summary>
        public int Price
        {
            get { return _price; }
            private set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("The price can not be less than zero!");
                }
                 
            }
        }

        /// <summary>
        /// Returns the products name, information and price.
        /// </summary>
        /// <returns>The products name, information and price</returns>
        public string Examine()
        {
            StringBuilder examinationInformation = new StringBuilder();

            examinationInformation.Append("Product:".PadRight(20));
            examinationInformation.Append($"{Name}\n");
            examinationInformation.Append("Information:".PadRight(20));
            examinationInformation.Append($"{Information}\n");
            examinationInformation.Append("Price:".PadRight(20));
            examinationInformation.Append($"{Price}\n");

            return examinationInformation.ToString();
        }

        /// <summary>
        /// Returns a use message.
        /// </summary>
        /// <returns>The use message</returns>
        public string Use()
        {
            return "The product is being used.";
        }
    }
}
