using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace service_request.Models
{

    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string? BuildingCode { get; set; }
        public string? Description { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceStatusType CurrentStatus { get; set; } 
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set;}

    }
}
