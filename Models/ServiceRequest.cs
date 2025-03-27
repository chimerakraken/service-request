using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace service_request.Models
{

    public enum ServiceStatusType
    {
        Open,
        InProgress,
        Completed,
        Canceled
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string? BuildingCode { get; set; }
        public string? Description { get; set; }
        public ServiceStatusType CurrentStatus { get; set; } 
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set;}

    }
}
