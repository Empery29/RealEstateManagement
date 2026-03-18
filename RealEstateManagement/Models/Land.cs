namespace RealEstateManagement.Models
{
    public class Land
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string SurveyNumber { get; set; }
        public string Title { get; set; }
        public decimal SizeSquareMeters { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public LandUsage Usage { get; set; }
        public LandStatus Status { get; set; }


    }

    public enum LandUsage
    {
        Residential,
        Commercial,
        Agriculture,
        Industrial,
        MixedUse
    }

    public enum LandStatus
    {
        Available,
        Resevered,
        Sold,
        UnderDispute,
        Leased
    }
}
