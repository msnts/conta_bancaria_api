using Newtonsoft.Json;

namespace ContaBancaria.API.Domain.Models
{
    public class ErrorDetails
    {
        [JsonProperty(PropertyName="status")]
        public int StatusCode { get; set; }
        [JsonProperty(PropertyName="title")]
        public string Message { get; set; }
 
 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}