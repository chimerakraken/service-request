using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace service_request.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceStatusType
    {
        NotApplicable,
        Created,
        InProgress,
        Complete,
        Canceled
    }
}
