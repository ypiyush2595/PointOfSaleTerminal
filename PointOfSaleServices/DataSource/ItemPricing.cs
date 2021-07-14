using PointOfSaleServices.Entities;
using System.Collections.Generic;

namespace PointOfSaleServices.DataSource
{
    public class ItemPricing
    {
        public List<Item> Items { get; set; }

        public ItemPricing() {
            LoadItems();
        }

        #region Private Methods

        private void LoadItems()
        {
            Items = new List<Item>
            {
                new Item{ItemName = "A", UnitPrice = 1.25M, VolumeUnit = 3, VolumePrice = 3M},
                new Item{ItemName = "B", UnitPrice = 4.25M, VolumeUnit = 0, VolumePrice = 0},
                new Item{ItemName = "C", UnitPrice = 1, VolumeUnit = 6, VolumePrice = 5M},
                new Item{ItemName = "D", UnitPrice = 0.75M, VolumeUnit = 0, VolumePrice = 0},
            };

        }

        #endregion Private Methods
    }
}
