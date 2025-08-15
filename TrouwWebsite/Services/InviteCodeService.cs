using TrouwWebsite.Models;
namespace TrouwWebsite.Services
{
    public class InviteCodeService
    {
        private static readonly Dictionary<string, InviteCode> _codes = new()
        {
            {
                "CHEF", new InviteCode
                {
                    Code = "CHEF",
                    Name = "Kitchen Masters",
                    Description = "De meesterkoks van onze grote dag - Familie & VIP's",
                    Emoji = "👨‍🍳",
                    AllowCeremonie = true,
                    AllowReceptie = true,
                    AllowDiner = true,
                    AllowFeest = true,
                    MaxGuests = 4,
                    Theme = "success"
                }
            },
            {
                "FOODIE", new InviteCode
                {
                    Code = "FOODIE",
                    Name = "Culinary Experts",
                    Description = "Echte kenners van de fijnere dingen in het leven",
                    Emoji = "🍽️",
                    AllowCeremonie = true,
                    AllowReceptie = true,
                    AllowDiner = true,
                    AllowFeest = true,
                    MaxGuests = 2,
                    Theme = "primary"
                }
            },
            {
                "APPETIZER", new InviteCode
                {
                    Code = "APPETIZER",
                    Name = "Light Bites",
                    Description = "Voor de voorsmaak van onze mooie dag",
                    Emoji = "🥗",
                    AllowCeremonie = false,
                    AllowReceptie = true,
                    AllowDiner = true,
                    AllowFeest = true,
                    MaxGuests = 2,
                    Theme = "info"
                }
            },
            {
                "SNACK", new InviteCode
                {
                    Code = "SNACK",
                    Name = "Quick Taste",
                    Description = "Een snelle hap en een drankje",
                    Emoji = "🥨",
                    AllowCeremonie = false,
                    AllowReceptie = true,
                    AllowDiner = false,
                    AllowFeest = true,
                    MaxGuests = 2,
                    Theme = "warning"
                }
            },
            {
                "TAKEAWAY", new InviteCode
                {
                    Code = "TAKEAWAY",
                    Name = "Grab & Go",
                    Description = "Even langs voor de felicitaties",
                    Emoji = "🥡",
                    AllowCeremonie = false,
                    AllowReceptie = true,
                    AllowDiner = false,
                    AllowFeest = false,
                    MaxGuests = 2,
                    Theme = "secondary"
                }
            },
            {
                "DESSERT", new InviteCode
                {
                    Code = "DESSERT",
                    Name = "Sweet Endings",
                    Description = "Voor het zoete slot van de avond",
                    Emoji = "🍰",
                    AllowCeremonie = false,
                    AllowReceptie = false,
                    AllowDiner = false,
                    AllowFeest = true,
                    MaxGuests = 2,
                    Theme = "danger"
                }
            }
        };

        public Task<InviteCode?> ValidateCodeAsync(string code)
        {
            _codes.TryGetValue(code.ToUpper(), out var inviteCode);
            return Task.FromResult(inviteCode);
        }

        public Task<List<InviteCode>> GetAllCodesAsync()
        {
            return Task.FromResult(_codes.Values.ToList());
        }
    }
}