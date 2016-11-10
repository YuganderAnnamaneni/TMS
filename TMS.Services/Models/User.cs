using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class User
    {
        [JsonProperty("uid")]
        public string UserId { get; set; }

        [JsonProperty("pwd")]
        public string Password { get; set; }

        [JsonProperty("user")]
        public string UserName { get; set; }

        [JsonProperty("token")]
        public string AuthToken { get; set; }
    }
}
