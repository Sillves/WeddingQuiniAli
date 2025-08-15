namespace TrouwWebsite.Models
{
    public class Registration
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string Naam { get; set; }
        public string Email { get; set; }
        public bool Trouwceremonie { get; set; }
        public bool Receptie { get; set; }
        public bool Diner { get; set; }
        public bool Feest { get; set; }
        public string PlusEen { get; set; }
        public string Dieetwensen { get; set; }
        public DateTime InschrijfDatum { get; set; } = DateTime.UtcNow;
    }
}