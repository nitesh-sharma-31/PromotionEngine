using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.PromotionEngine.Model;

namespace App.PromotionEngine.BusinessLogic.Test
{
    /// <summary>
    /// Summary description for CartManagerTest
    /// </summary>
    [TestClass]
    public class CartManagerTest
    {
        private ICartManager cartManager;

        public CartManagerTest()
        {
            cartManager = new CartManager();
        }

        private TestContext testContextInstance;

        [TestMethod]
        public void AddProduct_TwoProducts_CountTrue()
        {
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });

            var products = cartManager.GetProducts();

            Assert.AreEqual(2, products.Count);

        }

        [TestMethod]
        public void DeleteProduct_OneProduct_CountTrue()
        {
            cartManager.ClearCart();

            Product product = new Product() { Name = "A", ID = new Guid() };
            cartManager.AddProduct(product);
            cartManager.AddProduct(new Product() { Name = "A", ID = new Guid() });

            var products = cartManager.GetProducts();

            Assert.AreEqual(2, products.Count);

            cartManager.DeleteProduct(product);

            products = cartManager.GetProducts();

            Assert.AreEqual(1, products.Count);
        }
    }
}
