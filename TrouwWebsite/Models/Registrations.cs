namespace TrouwWebsite.Models
{
    public class Registration
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string Naam { get; set; }         // required modifier
        public string Email { get; set; }        // required modifier
        public bool BurgerlijkeTrouw { get; set; }
        public bool Huwelijksceremonie { get; set; }
        public bool Receptie { get; set; }
        public bool Diner { get; set; }
        public bool Dessertenbuffet { get; set; }
        public bool Avondfeest { get; set; }
        public string? PlusEen { get; set; }             // nullable
        public string? Dieetwensen { get; set; }         // nullable
        public DateTime InschrijfDatum { get; set; } = DateTime.UtcNow;
    }
}