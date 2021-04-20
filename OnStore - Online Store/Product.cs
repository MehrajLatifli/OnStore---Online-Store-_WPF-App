using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore___Online_Store
{
    public class Product
    {
        public Product(string productName, string productPrice, string productProducer, string productImagePath)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductProducer = productProducer;
            ProductImagePath = productImagePath;
        }

        public Product()
        {

        }

        public Product(string productName, string productPrice, string productProducer)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductProducer = productProducer;
        }

        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductProducer { get; set; }
        public string ProductImagePath { get; set; }
    }
}
