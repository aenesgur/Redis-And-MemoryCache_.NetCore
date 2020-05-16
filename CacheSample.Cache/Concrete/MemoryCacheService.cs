using CacheSample.Cache.Abstract;
using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Text;

namespace CacheSample.Cache.Concrete
{
    public class MemoryCacheService : IMemoryCacheManager
    {
        public void Add<T>(string key, T value, TimeSpan timeout) where T : class
        {
            if (value == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddSeconds(timeout.TotalSeconds));//  DateTime.Now + timeout;

            MemoryCache.Default.Add(new CacheItem(key, value), policy);
        }

        public T Get<T>(string key)
        {
            return (T)MemoryCache.Default[key];
        }

        public bool IsSet(string key)
        {
            return (MemoryCache.Default.Contains(key));
        }

        public bool Remove(string key)
        {
            try
            {
                MemoryCache.Default.Remove(key);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
    }
}
