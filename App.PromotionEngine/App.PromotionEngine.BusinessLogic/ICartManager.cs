using App.PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.BusinessLogic
{
    public interface ICartManager
    {
        void AddProduct(Product product);

        void DeleteProduct(Product product);

        List<Product> GetProducts();

        void ClearCart();
    }
}
