using Microsoft.Extensions.Configuration;
using PointOfSaleServices.Contracts;
using PointOfSaleServices.DataSource;
using PointOfSaleServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleServices
{

    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private List<Item> _scannedItems = new List<Item>();
        private readonly ItemPricing _itemPricing;

        public PointOfSaleTerminal(ItemPricing itemPricing)
        {
            _itemPricing = itemPricing;
        }

        public decimal CalculateTotal()
        {
            decimal totalPrice = 0;
            if (_scannedItems == null) return totalPrice;

            var groupedItems = _scannedItems.GroupBy(item => item.ItemName);

            foreach (var groupedItem in groupedItems)
            {
                var item = _itemPricing.Items.FirstOrDefault(item => item.ItemName == groupedItem.Key);
                var itemCount = groupedItem.ToList().Count;

                if (item.VolumeUnit > 0)
                {
                    var divRes = itemCount / item.VolumeUnit;
                    var modRes = itemCount % item.VolumeUnit;

                    totalPrice += divRes > 0 ? item.VolumePrice * divRes : 0;
                    totalPrice += modRes > 0 ? item.UnitPrice * modRes : 0;
                }
                else
                {
                    totalPrice += item.UnitPrice * itemCount;
                }

            }

            return totalPrice;
        }

        public void Scan(string itemName)
        {
            var item = _itemPricing.Items.FirstOrDefault(item => item.ItemName == itemName);
            if (item == null) throw new Exception("Item not found.");

            _scannedItems.Add(item);
        }

        public void SetPrice()
        {
            throw new NotImplementedException();
        }

    }
}
