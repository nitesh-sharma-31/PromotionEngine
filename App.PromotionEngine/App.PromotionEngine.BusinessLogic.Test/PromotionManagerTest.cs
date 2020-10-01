using System;
using System.Collections.Generic;
using App.PromotionEngine.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.PromotionEngine.BusinessLogic.Test
{
    [TestClass]
    public class PromotionManagerTest
    {
        private IPromotionManager promotionManager;
        private ICartManager cartManager;
        private Dictionary<string, double> unitPrice;

        public PromotionManagerTest()
        {
            unitPrice = new Dictionary<string, double>();
            unitPrice.Add("A", 50);
            unitPrice.Add("B", 30);
            unitPrice.Add("C", 20);
            unitPrice.Add("D", 15);

            
        }

        [TestMethod]
        public void AddPromotion_TwoAdded_CountMatch()
        {
            Assert.AreEqual(3, promotionManager.AvailblePromotions.Count);
        }

        [TestMethod]
        public void CheckOut_ApplyPromotion_FinalPrice()
        {
            Assert.AreEqual(3, promotionManager.AvailblePromotions.Count);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            cartManager = new CartManager();
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

            promotionManager = new PromotionManager(cartManager, unitPrice);
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

            Assert.AreEqual(280, amountToBePaid);
        }
    }
}
