namespace PointOfSaleServices.Contracts
{
    public interface IPointOfSaleTerminal
    {
        public void SetPrice();

        public void Scan(string itemName);

        public decimal CalculateTotal();
    }
}
