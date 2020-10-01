using App.PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.BusinessLogic
{
    public class CartManager
    {
        private List<Product> Cart = new List<Product>();

        public void AddProduct(Product product)
        {
            Cart.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            Cart.Remove(product);
        }

        public List<Product> GetProducts()
        {
            return Cart;
        }
    }
}
