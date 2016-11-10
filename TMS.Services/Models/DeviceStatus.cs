﻿using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class DeviceStatus
    {
        [JsonProperty("deviceid")]
        public string ВeviceId { get; set; }

        [JsonProperty("ac_on")]
        public string Ac_On { get; set; }

        [JsonProperty("dev_timestamp")]
        public string DeviceTimestamp { get; set; }
    }
}
