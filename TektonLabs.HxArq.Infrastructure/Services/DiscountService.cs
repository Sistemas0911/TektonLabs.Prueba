using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TektonLabs.HxArq.Infrastructure.Configurations;
using TektonLabs.HxArq.Infrastructure.Services.Entities;

namespace TektonLabs.HxArq.Infrastructure.Services
{
    public class DiscountService
    {
        private readonly HttpClient _httpClient;
        private readonly DiscountServiceSettings _discountServiceSettings;

        public DiscountService(HttpClient httpClient, IOptions<DiscountServiceSettings> discountServiceSettings)
        {
            _httpClient = httpClient;
            _discountServiceSettings = discountServiceSettings.Value;
        }

        public async Task<int> GetDiscountAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"{_discountServiceSettings.ServiceUrl}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var discount = JsonSerializer.Deserialize<List<DiscountEntity>>(content);
            return discount.FirstOrDefault().discount;
        }

    }
}
