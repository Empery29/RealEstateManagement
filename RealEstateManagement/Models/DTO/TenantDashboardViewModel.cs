namespace RealEstateManagement.Models.DTO
{
    public class TenantDashboardViewModel
    {
        public Tenant CurrentTenant { get; set; }
        public List<Tenant> PastTenants { get; set; }
        public List<MaintenanceRequest> MaintenanceRequests { get; set; }
    }
}

