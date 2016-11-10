using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class Tag
    {
        [JsonProperty("tag_id")]
        public string TagId { get; set; }
    }
}
