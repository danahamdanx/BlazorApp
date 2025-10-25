using ElectricMeterApp.Models;

namespace ElectricMeterApp.Services
{
    public class ElectricMeterService : IElectricMeterService
    {
        private readonly Random _random = new();

        public async Task<MeterQueryResponse> QueryMeterAsync(MeterQueryRequest request)
        {
            // Simulate API call delay
            await Task.Delay(1000);

            // Simulate successful response matching the exact JSON structure
            return new MeterQueryResponse
            {
                Success = true,
                AccountNumber = "100166299",
                AccountUsed = "2522",
                CustomerName = "صالح",
                MeterNumber = request.MeterNo,
                QueryRef = _random.Next(10000000, 99999999).ToString(),
                Adjustments = 19.6m,
                RechargeAmount = request.Amount - 19.6m,
                Timestamp = DateTime.Now,
                AdjustmentsDetails = new List<AdjustmentDetail>
        {
            new()
            {
                AdjustmentName = "رسوم جباية نفايات",
                AdjustmentRemains = "0.0",
                AdjustmentValue = "19.6"
            }
        }
            };
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(MeterQueryRequest request)
        {
            // Simulate API call delay
            await Task.Delay(1500);

            // Calculate units based on amount (15.5 units for 50.0 amount as in the example)
            decimal unitsAdded = Math.Round(request.Amount * 0.31m, 1);

            // Simulate successful payment response matching the exact JSON structure
            return new PaymentResponse
            {
                Success = true,
                MeterNumber = request.MeterNo,
                CustomerName = "أحمد محمد",
                AccountNumber = "123456789",
                AmountPaid = request.Amount,
                UnitsAdded = unitsAdded,
                Token = $"{_random.Next(1000, 9999)}-{_random.Next(1000, 9999)}-{_random.Next(1000, 9999)}-{_random.Next(1000, 9999)}",
                ReferenceNumber = $"rtr_{DateTime.Now:yyyyMMdd}_{_random.Next(1000, 9999):D3}",
                AccountUsed = "account_username",
                Timestamp = DateTime.Now
            };
        }
    }
}