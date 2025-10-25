using ElectricMeterApp.Models;
using Microsoft.JSInterop;

namespace ElectricMeterApp.Services
{
    public interface ILocalStorageService
    {
        Task SaveRecentQueryAsync(MeterQueryRequest request, MeterQueryResponse response);
        Task<List<MeterQueryRequest>> GetRecentQueriesAsync();
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string RecentQueriesKey = "recentQueries";

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveRecentQueryAsync(MeterQueryRequest request, MeterQueryResponse response)
        {
            try
            {
                // Create a new request with timestamp
                var requestWithTimestamp = new MeterQueryRequest
                {
                    MeterNo = request.MeterNo,
                    Amount = request.Amount,
                    Timestamp = DateTime.Now
                };

                await _jsRuntime.InvokeVoidAsync("saveToLocalStorage", RecentQueriesKey, requestWithTimestamp);
            }
            catch (Exception ex)
            {
                // Silently fail - local storage might not be available
                Console.WriteLine($"Note: Could not save to local storage: {ex.Message}");
            }
        }

        public async Task<List<MeterQueryRequest>> GetRecentQueriesAsync()
        {
            try
            {
                var queries = await _jsRuntime.InvokeAsync<List<MeterQueryRequest>>("getFromLocalStorage", RecentQueriesKey);
                return queries?.OrderByDescending(q => q.Timestamp).ToList() ?? new List<MeterQueryRequest>();
            }
            catch (Exception ex)
            {
                // Silently fail - local storage might not be available
                Console.WriteLine($"Note: Could not read from local storage: {ex.Message}");
                return new List<MeterQueryRequest>();
            }
        }
    }
}