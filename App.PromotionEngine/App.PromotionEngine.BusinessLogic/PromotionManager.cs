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

        private void ApplyPromotion()
        {
            tempProducts = CartManager.GetProducts();
            
            foreach (var promo in AvailblePromotions)
            {
                while(IsPromoApplicable(promo.Combinations))
                {
                    ApplyPromo(promo.Combinations);
                    AppliedPromotions.Add(promo);
                }
            }
        }

        private bool IsPromoApplicable(Dictionary<string, int> combinations)
        {
            bool result = true;

            foreach (var val in combinations)
            {
                var products = tempProducts.Where(x => x.Name == val.Key).ToList();

                if (products.Count() < val.Value)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private void ApplyPromo(Dictionary<string, int> combinations)
        {
            List<Product> matchProdutcs = new List<Product>();
            int combinationToBeCalculate = combinations.Count;

            foreach (var val in combinations)
            {
                var products = tempProducts.Where(x => x.Name == val.Key).ToList();

                if (products.Count() >= val.Value)
                {
                    for (int i = 0; i < val.Value; i++)
                    {
                        matchProdutcs.Add(products[i]);
                    }
                }

                foreach (var match in matchProdutcs)
                {
                    tempProducts.Remove(match);
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
