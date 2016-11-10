using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class Attendance
    {
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("tag_id")]
        public string TagId { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }
}
