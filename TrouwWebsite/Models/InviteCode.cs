namespace TrouwWebsite.Models
{
    public class InviteCode
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Emoji { get; set; } = string.Empty;
        public bool AllowCeremonie { get; set; }
        public bool AllowReceptie { get; set; }
        public bool AllowDiner { get; set; }
        public bool AllowFeest { get; set; }
        public int MaxGuests { get; set; } = 2;
        public string Theme { get; set; } = "primary";
    }
}