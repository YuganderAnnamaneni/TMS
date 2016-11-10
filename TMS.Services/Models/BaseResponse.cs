using Newtonsoft.Json;

namespace TMS.Services.Models
{
    public class BaseResponse<T>
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
