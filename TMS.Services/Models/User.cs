using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class User
    {
        [JsonProperty("uid")]
        public string UserId { get; set; }

        [JsonProperty("pwd")]
        public string Password { get; set; }
    }
}
