using service_request.Models;
using System.Text.Json.Serialization;

namespace service_request.Dtos
{

    public class UpdateServiceRequestDto
    {
        public string? BuildingCode { get; set; }
        public string? Description { get; set; }
        public string? LastModifiedBy { get; set; }
        public ServiceStatusType? CurrentStatus { get; set; }
    }
}
