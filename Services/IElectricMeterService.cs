using ElectricMeterApp.Models;

namespace ElectricMeterApp.Services
{
    public interface IElectricMeterService
    {
        Task<MeterQueryResponse> QueryMeterAsync(MeterQueryRequest request);
        Task<PaymentResponse> ProcessPaymentAsync(MeterQueryRequest request);
    }
}