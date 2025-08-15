using System.Text.Json.Serialization;

namespace TrouwWebsiteAPI.Models
{
    public class Registration
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();
        
        [JsonPropertyName("naam")]
        public string Naam { get; set; } = string.Empty;
        
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        
        [JsonPropertyName("trouwceremonie")]
        public bool Trouwceremonie { get; set; }
        
        [JsonPropertyName("receptie")]
        public bool Receptie { get; set; }
        
        [JsonPropertyName("diner")]
        public bool Diner { get; set; }
        
        [JsonPropertyName("feest")]
        public bool Feest { get; set; }
        
        [JsonPropertyName("plusEen")]
        public string PlusEen { get; set; } = string.Empty;
        
        [JsonPropertyName("dieetwensen")]
        public string Dieetwensen { get; set; } = string.Empty;
        
        [JsonPropertyName("inschrijfDatum")]
        public DateTime InschrijfDatum { get; set; } = DateTime.UtcNow;
    }
}