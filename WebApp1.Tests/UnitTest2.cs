﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System.Linq;
using Moq;

namespace WebApp1.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            // Arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);

            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            //var goalTotal = products.Sum(e => e.Price);

            var target = new LinqValueCalculator(mock.Object);

            // Act
            var result = target.ValueProducts(products);

            // Assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }
    }
}
