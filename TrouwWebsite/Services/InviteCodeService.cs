using TrouwWebsite.Models;

namespace TrouwWebsite.Services
{
    public class InviteCodeService
    {
        private readonly List<InviteCode> _inviteCodes;

        public InviteCodeService()
        {
            _inviteCodes = new List<InviteCode>
            {
                // Optie 1: FULLDAY - Alles
                new InviteCode
                {
                    Code = "JUSTITIEPALEIS",
                    Name = "Full Day",
                    Description = "Burgerlijke Trouw, huwelijksceremonie, receptie, diner, dessertenbuffet en avondfeest",
                    Emoji = "🎊",
                    AllowBurgerlijkeTrouw = true,
                    AllowHuwelijksCeremonie = true,
                    AllowReceptie = true,
                    AllowDiner = true,
                    AllowDessertenbuffet = true,
                    AllowAvondfeest = true,
                    MaxGuests = 2,
                    Theme = "primary"
                },
                // Optie 2: NOCHURCH - Alles behalve huwelijksceremonie
                new InviteCode
                {
                    Code = "KMSKA",
                    Name = "No Church",
                    Description = "Burgerlijke Trouw, receptie, diner, dessertenbuffet en avondfeest",
                    Emoji = "🥂",
                    AllowBurgerlijkeTrouw = true,
                    AllowHuwelijksCeremonie = false,
                    AllowReceptie = true,
                    AllowDiner = true,
                    AllowDessertenbuffet = true,
                    AllowAvondfeest = true,
                    MaxGuests = 2,
                    Theme = "success"
                },
                // Optie 3: SWEETPARTY - Alleen Burgerlijke Trouw, dessert en feest
                new InviteCode
                {
                    Code = "SINT KATELIJNEKERK",
                    Name = "Sweet Party",
                    Description = "Burgerlijke Trouw, dessertenbuffet en avondfeest",
                    Emoji = "🎉",
                    AllowBurgerlijkeTrouw = true,
                    AllowHuwelijksCeremonie = false,
                    AllowReceptie = false,
                    AllowDiner = false,
                    AllowDessertenbuffet = true,
                    AllowAvondfeest = true,
                    MaxGuests = 2,
                    Theme = "info"
                }
            };
        }

        public InviteCode? ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var upperCode = code.ToUpper().Trim();
            return _inviteCodes.FirstOrDefault(ic => ic.Code == upperCode);
        }

        public List<InviteCode> GetAllCodes()
        {
            return _inviteCodes.ToList();
        }

        public bool CodeExists(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return false;

            var upperCode = code.ToUpper().Trim();
            return _inviteCodes.Any(ic => ic.Code == upperCode);
        }

        public InviteCode? GetCodeByString(string code)
        {
            return ValidateCode(code);
        }
    }
}