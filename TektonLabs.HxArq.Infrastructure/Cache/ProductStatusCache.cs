using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace TektonLabs.HxArq.Infrastructure.Cache
{
    public class ProductStatusCache
    {
        private readonly IMemoryCache _cache;
        private static readonly Dictionary<int, string> StatusDictionary = new()
        {
            { 1, "Active" },
            { 0, "Inactive" }
        };

        public ProductStatusCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string GetStatusName(int status)
        {
            string? _status = _cache.GetOrCreate(status, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return StatusDictionary[status];
            });

            return string.IsNullOrEmpty(_status) ? string.Empty : _status;
        }
    }
}
