namespace RealEstateManagement.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
        public DateTime MoveInDate { get; set; }

        public List<Payment> Payments { get; set; } = [];
    }
}
