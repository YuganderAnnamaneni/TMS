using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class Device
    {
        [JsonProperty("heartbeat_time")]
        public string HeartBeatTime { get; set; }

        [JsonProperty("heartbeat_duration")]
        public string HeartBeatDuration { get; set; }

        [JsonProperty("reset_heartbeat_every_period")]
        public string ResetHeartBeatEveryPeriod { get; set; }
    }
}
