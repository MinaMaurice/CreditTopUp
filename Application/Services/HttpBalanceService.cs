using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HttpBalanceService : IHttpBalanceService
    {
        private readonly HttpClient _httpClient;

        public HttpBalanceService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<decimal> GetBalanceAsync(int userId)
        {
            // Make an HTTP request to the external service to get the user's balance
            HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:5240/api/users/{userId}/balance");

            if (response.IsSuccessStatusCode)
            {
                string balanceString = await response.Content.ReadAsStringAsync();
                if (decimal.TryParse(balanceString, out decimal balance))
                {
                    return balance;
                }
            }

            throw new Exception("Failed to retrieve balance from the external service.");
        }
        public async Task<bool> DeductBalanceAsync(int userId, decimal amount)
        {
            // Make an HTTP request to deduct the user's balance
            HttpResponseMessage response = await _httpClient.PostAsync($"http://localhost:5240/api/users/{userId}/deduct-balance?amount={amount}", null);

            // Return true if the deduction was successful, false otherwise
            return response.IsSuccessStatusCode;
        }
    }
}
