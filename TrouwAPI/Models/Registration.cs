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

        // Alle 6 events apart
        [JsonPropertyName("burgerlijkeTrouw")]
        public bool BurgerlijkeTrouw { get; set; }

        [JsonPropertyName("huwelijksceremonie")]
        public bool Huwelijksceremonie { get; set; }

        [JsonPropertyName("receptie")]
        public bool Receptie { get; set; }

        [JsonPropertyName("diner")]
        public bool Diner { get; set; }

        [JsonPropertyName("dessertenbuffet")]
        public bool Dessertenbuffet { get; set; }

        [JsonPropertyName("avondfeest")]
        public bool Avondfeest { get; set; }

        [JsonPropertyName("plusEen")]
        public string PlusEen { get; set; } = string.Empty;

        [JsonPropertyName("dieetwensen")]
        public string Dieetwensen { get; set; } = string.Empty;

        [JsonPropertyName("inschrijfDatum")]
        public DateTime InschrijfDatum { get; set; } = DateTime.UtcNow;
    }
}