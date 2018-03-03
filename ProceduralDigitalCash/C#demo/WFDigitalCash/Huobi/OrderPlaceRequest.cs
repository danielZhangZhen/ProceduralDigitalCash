using Newtonsoft.Json;

namespace WFDigitalCash
{
    public class OrderPlaceRequest
    {
        [JsonProperty("account-id")]
        public string account_id { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string source { get; set; }
        public string symbol { get; set; }
        public string type { get; set; }
    }
}