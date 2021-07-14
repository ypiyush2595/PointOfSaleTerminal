namespace PointOfSaleServices.Entities
{
    public class Item
    {
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int VolumeUnit { get; set; }
        public decimal VolumePrice { get; set; }
    }
}
