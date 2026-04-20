namespace RefactoringLab
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public bool IsRegular { get; set; }
        public int ItemsCount { get; set; }
        public int DeliveryType { get; set; }
    }
}