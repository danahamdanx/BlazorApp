namespace ElectricMeterApp.Models
{
    public class MeterQueryRequest
    {
        public string MeterNo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}