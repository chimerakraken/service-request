using service_request.Models;
using System.Text.Json.Serialization;

namespace service_request.Dtos
{

    public class CreateServiceRequestDto : ServiceRequest
    {
        [JsonIgnore] 
        public new int Id { get; set; }
    }
}
