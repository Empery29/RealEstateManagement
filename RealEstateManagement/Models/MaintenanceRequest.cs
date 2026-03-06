namespace RealEstateManagement.Models
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

        public string Issue { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime DateReported { get; set; }
    }
}
