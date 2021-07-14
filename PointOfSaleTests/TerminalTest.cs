using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PointOfSaleServices;
using PointOfSaleServices.Contracts;
using PointOfSaleServices.DataSource;
using System.Collections.Generic;

namespace PointOfSaleTests
{
    [TestFixture]
    public class Tests
    {
        private PointOfSaleTerminal _pointOfSaleTerminal;

        [SetUp]
        public void Setup()
        {
            ItemPricing itemPricing = new ItemPricing();
            _pointOfSaleTerminal = new PointOfSaleTerminal(itemPricing);
        }

        [Test]
        public void Test1()
        {
            var items = new List<string> { "A", "B", "C", "D", "A", "B","A"};
            foreach (var item in items)
            {
                _pointOfSaleTerminal.Scan(item);
            }

            var totalPrice = _pointOfSaleTerminal.CalculateTotal();
            Assert.AreEqual(13.25, totalPrice);
        }

        [Test]
        public void Test2()
        {
            var items = new List<string> { "C", "C", "C", "C", "C", "C", "C" };
            foreach (var item in items)
            {
                _pointOfSaleTerminal.Scan(item);
            }

            var totalPrice = _pointOfSaleTerminal.CalculateTotal();
            Assert.AreEqual(6, totalPrice);
        }


        [Test]
        public void Test3()
        {
            var items = new List<string> { "A", "B", "C", "D"};
            foreach (var item in items)
            {
                _pointOfSaleTerminal.Scan(item);
            }

            var totalPrice = _pointOfSaleTerminal.CalculateTotal();
            Assert.AreEqual(7.25, totalPrice);
        }
    }
}