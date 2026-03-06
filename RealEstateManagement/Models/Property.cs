namespace RealEstateManagement.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int Bedrooms { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<Tenant> Tenants { get; set; } = [];
    }
}
