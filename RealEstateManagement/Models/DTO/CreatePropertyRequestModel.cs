namespace RealEstateManagement.Models.DTO
{
    public class CreatePropertyRequestModel
    {
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int Bedrooms { get; set; }
        public bool IsAvailable { get; set; }
        public string IsForSale { get; set; }
        public string IsFlat { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
