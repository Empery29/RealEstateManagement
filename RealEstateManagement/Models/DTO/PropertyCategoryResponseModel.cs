namespace RealEstateManagement.Models.DTO
{
    public class PropertyCategoryResponseModel
    {
        public List<Property> HouseForSale { get; set; }
        public List<Property> HouseForRent { get; set; }
        public List<Property> FlatForSale { get; set; }
        public List<Property> FlatForRent { get; set; }
    }
}
