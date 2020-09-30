using App.PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PromotionEngine.BusinessLogic
{
    public class PromotionManager
    {
        CartManager CartManager;
        List<Promotion> AvailblePromotions;
        List<Promotion> AppliedPromotions;
        Dictionary<string, double> UnitPrice;
        List<Product> tempProducts;

        public PromotionManager(CartManager cartManager, Dictionary<string, double> unitPrice)
        {
            CartManager = cartManager;
            AvailblePromotions = new List<Promotion>();
            AppliedPromotions = new List<Promotion>();
            UnitPrice = unitPrice;
        }

        public void ApplyPromotion()
        {
            tempProducts = CartManager.GetProducts();
            
            foreach (var promo in AvailblePromotions)
            {
                List<Product> matchProdutcs = new List<Product>();
                int combinationToBeCalculate = promo.Combinations.Count;

                foreach (var val in promo.Combinations)
                {
                    var products = tempProducts.Where(x => x.Name == val.Key).ToList();
                    matchProdutcs.AddRange(products);

                    if(products.Count() >= val.Value)
                    {
                        combinationToBeCalculate = combinationToBeCalculate - 1;
                        matchProdutcs.AddRange(products);
                    }
                }

                if(combinationToBeCalculate == 0)
                {
                    AppliedPromotions.Add(promo);

                    foreach(var match in matchProdutcs)
                    {
                        tempProducts.Remove(match);
                    }
                }
            }
        }

        public void AddPromotion(Promotion promotion)
        {
            AvailblePromotions.Add(promotion);
        }

        public double CheckOut()
        {
            double finalAmount = 0;
            this.ApplyPromotion();
            this.CalculatedFinalPrice();
            finalAmount = CalculatedFinalPrice();

            return finalAmount;
        }

        private double CalculatedFinalPrice()
        {
            double output = 0;
            foreach(var promo in AppliedPromotions)
            {
                output = output + promo.Amount;
            }

            foreach(var prod in tempProducts)
            {
                var val = UnitPrice[prod.Name];
                output = output + val;
            }

            return output;
        }
    }
}
