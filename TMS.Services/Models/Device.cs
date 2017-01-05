using Newtonsoft.Json;
using System.Collections.Generic;

namespace TMS.Services.Models
{
    public class Device
    {
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("heartbeat_time")]
        public string HeartBeatTime { get; set; }

        [JsonProperty("heartbeat_duration")]
        public string HeartBeatDuration { get; set; }

        [JsonProperty("reset_heartbeat_every_period")]
        public string ResetHeartBeatEveryPeriod { get; set; }

        [JsonProperty("attendance")]
        public List<Attendance> AttendanceList { get; set; }
    }
}
