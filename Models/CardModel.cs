namespace Task3.Models
{
    public class CardModel
    {
        public string CardType { get; set; } = "";
        public string LastFourDigits { get; set; } = "";
        public string ExpiryDate { get; set; } = "";
        public bool IsDefault { get; set; } = false;
        public string CardNumber { get; set; } = "";
        public string CardHolder { get; set; } = "";
        public string CVV { get; set; } = "";
    }
}