namespace RealEstateManagement.Models
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }
        public string TenantName { get; set; }
        public string TenantEmail { get; set; }
        public int UserId { get; set; }

        public string? PropertyTitle { get; set; }
      //  public Property Property { get; set; }

        public string Issue { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime DateReported { get; set; }
    }
}
