using App.PromotionEngine.BusinessLogic;
using App.PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> unitPrice = new Dictionary<string, double>();
            unitPrice.Add("A", 50);
            unitPrice.Add("B", 30);
            unitPrice.Add("C", 20);
            unitPrice.Add("D", 15);

            CartManager cartManager = new CartManager();
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "B", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "B", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "B", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "B", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "B", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "C", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "D", ID = new Guid() });

            PromotionManager promotionManager = new PromotionManager(cartManager, unitPrice);
            Promotion promotion = new Promotion();
            promotion.Combinations.Add("A", 3);
            promotion.Amount = 130;

            Promotion promotion2 = new Promotion();
            promotion2.Combinations.Add("B", 2);
            promotion2.Amount = 45;

            Promotion promotion3 = new Promotion();
            promotion3.Combinations.Add("C", 1);
            promotion3.Combinations.Add("D", 1);
            promotion3.Amount = 30;

            promotionManager.AddPromotion(promotion);
            promotionManager.AddPromotion(promotion2);
            promotionManager.AddPromotion(promotion3);
            double amountToBePaid = promotionManager.CheckOut();

            Console.WriteLine(amountToBePaid);
            Console.ReadLine();
        }
    }
}
